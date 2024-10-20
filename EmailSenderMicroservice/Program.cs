using EmailSenderMicroservice.Application.Mapper;
using EmailSenderMicroservice.Application.Services;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess;
using EmailSenderMicroservice.DataAccess.Repositories;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Helpers;
using EmailSenderMicroservice.Mapper;
using EmailSenderMicroservice.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EmailSenderMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionStringDb = builder.Configuration.GetConnectionString(nameof(EmailSenderMicroserviceDbContext));

            if (string.IsNullOrEmpty(connectionStringDb))
            {
                throw new InvalidOperationException("Connection string for EmailSenderMicroserviceDbContext is not configured.");
            }

            var connectionStringRMQ = builder.Configuration.GetConnectionString(nameof(EmailSendedConsumer));

            if (string.IsNullOrEmpty(connectionStringRMQ))
            {
                throw new InvalidOperationException("Connection string for RabbitMQ is not configured.");
            }

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Email Sender API",
                        Description = "The Email Sender API provides endpoints for managing and retrieving email messages. This API allows you to fetch all email messages or retrieve a specific message by its unique identifier."
                    });
                });

            builder.Services.AddDbContext<EmailSenderMicroserviceDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionStringDb);
                });

            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<ISettingService, SettingService>();
            builder.Services.AddScoped<ISettingRepository, SettingRepository>();

            builder.Services.AddScoped<SenderService>();

            builder.Services.AddAutoMapper(typeof(RepresentationProfile), typeof(ApplicationProfile));

            builder.Services.AddLogging(builder => builder.AddConsole());

            builder.Services.AddHealthChecks()
                .AddNpgSql(connectionStringDb)
                .AddRabbitMQ(rabbitConnectionString: connectionStringRMQ)
                .AddDbContextCheck<EmailSenderMicroserviceDbContext>();

            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(Program).Assembly);
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(connectionStringRMQ));
                    cfg.ConfigureEndpoints(context);
                    cfg.UseMessageRetry(r =>
                    {
                        r.Interval(3, TimeSpan.FromSeconds(10));
                    });
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();

            app.UseCors(policy =>
            {
                policy.WithOrigins("http://localhost:5173")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.MapHealthChecks("health", new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseAuthorization();

            app.MigrateDatabase<EmailSenderMicroserviceDbContext>();

            app.MapControllers();

            app.Run();
        }
    }
}

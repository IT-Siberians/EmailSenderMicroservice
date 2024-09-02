using EmailSenderMicroservice.Application.Mapper;
using EmailSenderMicroservice.Application.Services;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess;
using EmailSenderMicroservice.DataAccess.Repositories;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Mapper;
using EmailSenderMicroservice.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace EmailSenderMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
                    var connectionString = builder.Configuration.GetConnectionString(nameof(EmailSenderMicroserviceDbContext));

                    if (string.IsNullOrEmpty(connectionString))
                    {
                        throw new InvalidOperationException("Connection string for EmailSenderMicroserviceDbContext is not configured.");
                    }

                    options.UseNpgsql(connectionString);
                });

            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<ISettingService, SettingService>();
            builder.Services.AddScoped<ISettingRepository, SettingRepository>();

            builder.Services.AddScoped<SenderService>();

            builder.Services.AddHostedService<EmailConsumerService>();

            builder.Services.AddAutoMapper(typeof(RepresentationProfile), typeof(ApplicationProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

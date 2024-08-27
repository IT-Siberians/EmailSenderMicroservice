using EmailSenderMicroservice.Application.Mapper;
using EmailSenderMicroservice.Application.Services;
using EmailSenderMicroservice.Application.Services.Abstraction;
using EmailSenderMicroservice.DataAccess;
using EmailSenderMicroservice.DataAccess.Repositories;
using EmailSenderMicroservice.DataAccess.Repositories.Abstraction;
using EmailSenderMicroservice.Mapper;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EmailSenderMicroserviceDbContext>(
                options =>
                {
                    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(EmailSenderMicroserviceDbContext)));
                });

            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            builder.Services.AddScoped<ISettingService, SettingService>();
            builder.Services.AddScoped<ISettingRepository, SettingRepository>();

            // builder.Services.AddHostedService<EmailConsumerService>(); // не запускается

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

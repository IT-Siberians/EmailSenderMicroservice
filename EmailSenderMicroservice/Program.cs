using EmailSenderMicroservice.Application.Interface;
using EmailSenderMicroservice.Application.Mapper;
using EmailSenderMicroservice.Application.Services;
using EmailSenderMicroservice.DataAccess;
using EmailSenderMicroservice.DataAccess.Interface;
using EmailSenderMicroservice.DataAccess.Repossitory;
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

            builder.Services.AddAutoMapper(typeof(RepProfile), typeof(AppProfile));
          //  builder.Services.AddAutoMapper(typeof(AppProfile));


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

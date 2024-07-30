using EmailSenderMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess
{
    public class EmailSenderMicroserviceDbContext : DbContext
    {
        public EmailSenderMicroserviceDbContext(DbContextOptions<EmailSenderMicroserviceDbContext> options) 
            : base(options)
        {
        }

        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
    }
}

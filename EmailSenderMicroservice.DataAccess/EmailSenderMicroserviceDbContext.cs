using EmailSenderMicroservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderMicroservice.DataAccess
{
    public class EmailSenderMicroserviceDbContext : DbContext
    {
        public EmailSenderMicroserviceDbContext(DbContextOptions<EmailSenderMicroserviceDbContext> options) 
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}

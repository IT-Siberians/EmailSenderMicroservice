using EmailSenderMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailSenderMicroservice.DataAccess.Configuration
{
    internal class SettingConfiguration : IEntityTypeConfiguration<SettingEntity>
    {
        public void Configure(EntityTypeBuilder<SettingEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServerAddress)
                .IsRequired();

            builder.Property(x => x.ServerPort)
                .IsRequired();

            builder.Property(x=>x.UseSSL)
                .IsRequired();
            
            builder.Property(x=>x.Login)
                .IsRequired();

            builder.Property(x=>x.Password)
                .IsRequired();

            builder.Property(x=>x.CreateDate)
                .IsRequired();
            
        }
    }
}

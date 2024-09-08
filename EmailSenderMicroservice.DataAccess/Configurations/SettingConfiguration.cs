using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailSenderMicroservice.DataAccess.Configurations
{
    internal class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Connection)
                .Property(p => p.Address)
                .HasColumnName("ServerAddress");

            builder.OwnsOne(x => x.Connection)
                .Property(p => p.Port)
                .HasColumnName("ServerPort");

            builder.Property(x => x.UseSSL);

            builder.Property(x => x.Login)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v))
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();

        }
    }
}

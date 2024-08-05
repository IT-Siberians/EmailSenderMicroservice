using EmailSenderMicroservice.Domain.Models;
using EmailSenderMicroservice.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace EmailSenderMicroservice.DataAccess.Configuration
{
    internal class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Connection)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<Connection>(v, (JsonSerializerOptions)null))
                .IsRequired();

            builder.Property(x => x.UseSSL);

            builder.Property(x => x.Login)
                .HasConversion(
                    v => v.Value,
                    v => new Email(v))
                .IsRequired();

            builder.Property(x => x.Password)
                .IsRequired();

            builder.Property(x => x.CreateDate)
                .IsRequired();

        }
    }
}

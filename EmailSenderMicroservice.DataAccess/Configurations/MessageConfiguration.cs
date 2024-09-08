using EmailSenderMicroservice.Domain.Entities;
using EmailSenderMicroservice.Domain.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailSenderMicroservice.DataAccess.Configurations
{
    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Email)
                .HasConversion(
                    v => v.Value, 
                    v => new Email(v))
                .IsRequired();

            builder.Property(x => x.MessageType)
                .IsRequired();

            builder.Property(x => x.MessageText)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.CreationDate)
                .IsRequired();
        }
    }
}

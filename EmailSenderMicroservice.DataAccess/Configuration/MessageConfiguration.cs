using EmailSenderMicroservice.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmailSenderMicroservice.DataAccess.Configuration
{
    internal class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.Text)
                .IsRequired();

            builder.Property(x => x.Status);

            builder.Property(x => x.CreateDate)
                .IsRequired();
        }
    }
}

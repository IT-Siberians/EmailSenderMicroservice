namespace EmailSenderMicroservice.DataAccess.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

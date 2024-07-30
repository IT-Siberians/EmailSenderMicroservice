namespace EmailSenderMicroservice.DataAccess.Entities
{
    public class SettingEntity
    {
        public Guid Id {  get; set; }
        public string ServerAddress {  get; set; } = string.Empty;
        public uint ServerPort {  get; set; }
        public bool UseSSL {  get; set; }
        public string Login {  get; set; } = string.Empty;
        public string Password {  get; set; } = string.Empty;
        public DateTime CreateDate {  get; set; }
    }
}

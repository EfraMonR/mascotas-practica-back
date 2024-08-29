namespace MascotasBack.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}

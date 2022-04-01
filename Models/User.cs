namespace MVController.Models
{
    public class User
    {
        public string? Username { get; set; } = null;
        public string? Email { get; set; } = null;
        public User() { }
        public object SetUsername(string username) => Username = username;
        public object SetEmail(string email) => Email = email;
    }
}
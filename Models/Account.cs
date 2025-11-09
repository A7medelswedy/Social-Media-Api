namespace Social_Media_Web_API.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        // العلاقة مع الـ User Profile
        public User? User { get; set; }
    }
}

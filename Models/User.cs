namespace Social_Media_Web_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string Icon { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
    }
}

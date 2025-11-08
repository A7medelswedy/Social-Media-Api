namespace Social_Media_Web_API.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Relationship
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

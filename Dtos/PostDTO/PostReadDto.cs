namespace Social_Media_Web_API.Dtos.PostDTO
{
    public class PostReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        
        // string not datetime
        public string CreatedAt { get; set; }
    }
}

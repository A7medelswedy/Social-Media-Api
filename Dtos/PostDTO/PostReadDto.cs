namespace Social_Media_Web_API.Dtos.PostDTO
{
    public class PostReadDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; } // ناخدها من User
        public DateTime CreatedAt { get; set; }
    }

}

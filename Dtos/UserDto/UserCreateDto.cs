namespace Social_Media_Web_API.Dtos.UserDto
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string Icon { get; set; }
        public int AccountId { get; set; }  // ربط User بالـ Account
    }
}

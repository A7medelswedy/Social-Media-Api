namespace Social_Media_Web_API.Dtos.AccountDTO
{
    public class AccountCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

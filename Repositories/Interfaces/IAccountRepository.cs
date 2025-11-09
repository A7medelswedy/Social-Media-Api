using Social_Media_Web_API.Models;

namespace Social_Media_Web_API.Repositories.Interfaces
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task<Account?> GetByEmailAsync(string email);
        Task<Account?> GetByIdAsync(int id);
    }
}

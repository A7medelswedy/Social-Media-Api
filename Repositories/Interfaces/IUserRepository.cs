using Social_Media_Web_API.Models;

namespace Social_Media_Web_API.Repositories.Interfaces
{
   

        public interface IUserRepository : IGenericRepository<User>
        {
            Task<User?> GetUserWithPostsAsync(int id);
        Task<User?> GetByAccountIdAsync(int accountId);
        }
    
}

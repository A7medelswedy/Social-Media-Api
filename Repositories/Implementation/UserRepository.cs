using Microsoft.EntityFrameworkCore;
using Social_Media_Web_API.Data;
using Social_Media_Web_API.Models;
using Social_Media_Web_API.Repositories.Interfaces;

namespace Social_Media_Web_API.Repositories.Implementation
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByAccountIdAsync(int accountId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.AccountId == accountId);
        }

        public async Task<User?> GetUserWithPostsAsync(int id)
        {
            return await _context.Users
                .Include(u => u.Posts)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

using Social_Media_Web_API.Models;

namespace Social_Media_Web_API.Repositories.Interfaces
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithUsersAsync();
        Task<Post> GetByIdWithUserAsync(int id);
    }
}

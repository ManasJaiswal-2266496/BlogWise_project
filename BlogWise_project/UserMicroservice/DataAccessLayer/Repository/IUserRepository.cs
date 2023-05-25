using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.DataAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int userId);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int userId);
        Task<User> CreateUserAsync(User user);
    }
}

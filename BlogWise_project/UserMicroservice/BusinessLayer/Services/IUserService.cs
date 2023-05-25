using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroservice.BusinessLayer.ModelDto;

namespace UserMicroservice.BusinessLayer.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int userId);
        Task<UserDto> CreateUserAsync(UserDto user);
        Task<bool> UpdateUserAsync(UserDto user);
        Task<bool> DeleteUserAsync(int userId);
    }
}

using UserMicroservice.BusinessLayer.ModelDto;
using UserMicroservice.DataAccessLayer.Repository;
using UserMicroservice.DataAccessLayer.Models;

namespace UserMicroservice.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return MapToUserDtos(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return MapToUserDto(user);
        }

        public async Task<UserDto> CreateUserAsync(UserDto user)
        {
            var newUser = MapToUser(user);
            newUser.CreatedAt = DateTime.Now;

            var createdUser = await _userRepository.CreateUserAsync(newUser);
            return MapToUserDto(createdUser);
        }

        public async Task<bool> UpdateUserAsync(UserDto user)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(user.UserId);
            if (existingUser == null)
                return false;

            existingUser.Name = user.UserName;
            existingUser.Email = user.Email;
            existingUser.ModifiedAt = DateTime.Now;

            await _userRepository.UpdateUserAsync(existingUser);
            return true;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(userId);
            if (existingUser == null)
                return false;

            await _userRepository.DeleteUserAsync(existingUser.Id);
            return true;
        }

        private UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                UserName = user.Name,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                ModifiedAt = user.ModifiedAt
            };
        }

        private IEnumerable<UserDto> MapToUserDtos(IEnumerable<User> users)
        {
            var userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                userDtos.Add(MapToUserDto(user));
            }
            return userDtos;
        }

        private User MapToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.UserId,
                Name = userDto.UserName,
                Email = userDto.Email,
                CreatedAt = userDto.CreatedAt,
                ModifiedAt = userDto.ModifiedAt
            };
        }
    }
}

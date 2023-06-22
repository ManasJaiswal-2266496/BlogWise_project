using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserMicroservice.BusinessLayer.ModelDto;
using UserMicroservice.BusinessLayer.Services;
using UserMicroservice.DataAccessLayer.Models;
using UserMicroservice.DataAccessLayer.Repository;

namespace UserMicroservice.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        //private readonly IJWTManagerRepository _jwtManagerRepository;

        public UserController(IUserService userService /*,IJWTManagerRepository jwtManagerRepository*/)
        {
            _userService = userService;
            //_jwtManagerRepository = jwtManagerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserDto user)
        {
            if (id != user.UserId)
                return BadRequest();

            var result = await _userService.UpdateUserAsync(user);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        /*[HttpPost("authenticate")]
        public IActionResult Authenticate(UserDto userDto)
        {
            var user = MapUserDtoToUser(userDto);

            // Authenticate the user
            var token = _jwtManagerRepository.Authenticate(user);

            if (token == null)
                return Unauthorized();

            // Return the token as a response
            return Ok(new { Token = token });
        }*/

        /*[HttpGet("list")]
        public IActionResult GetUsersWithAuthentication()
        {
            // Retrieve the JWT token from the request headers
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // Validate the token
            var isValidToken = _jwtManagerRepository.IsTokenValid(token);

            if (!isValidToken)
                return Unauthorized();

            // Retrieve the list of users
            var users = _userService.GetAllUsersAsync().Result;

            return Ok(users);
        }*/

        private User MapUserDtoToUser(UserDto userDto)
        {
            return new User
            {
                Id = userDto.UserId, // Update this line to map UserId to Id
                Username = userDto.UserName,
                Password = userDto.Password
            };
        }
    }
}

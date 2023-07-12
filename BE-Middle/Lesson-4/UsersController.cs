using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var users = _userService.GetUsers();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email
                });
            }

            return Ok(userDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return Ok(userDto);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserCreateDto userCreateDto)
        {
            var user = new User
            {
                Name = userCreateDto.Name,
                Email = userCreateDto.Email
            };

            _userService.CreateUser(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, userDto);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(int id, UserUpdateDto userUpdateDto)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            user.Name = userUpdateDto.Name;
            user.Email = userUpdateDto.Email;

            _userService.UpdateUser(user);

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };

            return Ok(userDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(user);

            return NoContent();
        }
    }
}

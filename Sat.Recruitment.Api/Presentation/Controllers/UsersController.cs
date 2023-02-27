using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.BusinessLogic.Services;

namespace Sat.Recruitment.Api.Presentation.Models.Controllers
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


        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            var user = _userService.CreateNewUserByType(userRequest.Name, userRequest.Email, userRequest.Address, userRequest.Phone, userRequest.UserType, userRequest.Money);

            // Validations
            if (await _userService.ExistUserAsync(user))
            {
                return BadRequest("The user is duplicated");
            }

            // Storing user
            var userStored = await _userService.StorerUserAsync(user);

            var response = new UserResponse()
            {
                Name = userStored.Name,
                Email = userStored.Email,
                Address = userStored.Address,
                Phone = userStored.Phone,
                UserType = userStored.Type.ToString(),
                Money = userStored.Money
            };

            return Ok(response);
        }
    }
}

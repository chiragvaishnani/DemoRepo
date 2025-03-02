using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models.Models;
using TaskManagementWebAPI.Repository;

namespace TaskManagementWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public RegisterController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //add new user
        [HttpPost("RegisterUser")]
        public async Task<ActionResult> AddUser([FromBody] RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.AddUser(model);
                return result == 0 ? Ok(result) : BadRequest($"Error occurred, try again!");
            }
            else
                return BadRequest(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }

    }
}

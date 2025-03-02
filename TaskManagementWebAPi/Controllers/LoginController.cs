using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models.Models;
using TaskManagementWebAPI.Repository;

namespace TaskManagementWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpPost("ValidateUser")]
        public async Task<ActionResult> ValidateUser([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.ValidateUser(model);
                return result > 0 ? Ok(result) : BadRequest($"Error occurred, try again!");
            }
            else
                return BadRequest(string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage))));
        }

    }
}

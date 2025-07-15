using EnglishHelper.Application.DTOs;
using EnglishHelper.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnglishHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            try
            {
                var result = await _userService.RegisterAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO model)
        {
            try
            {
                var result = await _userService.LoginAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}


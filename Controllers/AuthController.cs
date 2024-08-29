using MascotasBack.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MascotasBack.Entities;
using MascotasBack.Services;
using MascotasBack.Interfaces;
using MascotasBack.Models;

namespace MascotasBack.Controllers
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
        public async Task<IActionResult> Register([FromBody] Users request)
        {
            try
            {
                await _userService.RegisterAsync(request);
                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            try
            {
                var isValid = await _userService.ValidateUserAsync(request.Email, request.Password);
                if (!isValid)
                {
                    return Unauthorized();
                }

                return Ok(new { message = "Login successful" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}

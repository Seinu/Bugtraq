using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using bugtraq.API.Data;
using bugtraq.API.Dtos;
using bugtraq.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace bugtraq.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthRepository _repo;
    private readonly IConfiguration _config;

    public AuthController(IAuthRepository repo, IConfiguration config)
    {
      _config = config;
      _repo = repo;
    }

    [HttpPost("register")]

    public async Task<IActionResult> Register(DevForRegisterDto devForRegisterDto)
    {
      devForRegisterDto.Email = devForRegisterDto.Email.ToLower();

      if (await _repo.EmailExists(devForRegisterDto.Email))
      {
        return BadRequest("Email already in use.");
      }

      var devToCreate = new Developer
      {
        Email = devForRegisterDto.Email
      };

      var createdDeveloper = await _repo.Register(devToCreate, devForRegisterDto.Password, devForRegisterDto.FirstName, devForRegisterDto.LastName, devForRegisterDto.Department);

      return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(DevForLoginDto devForLoginDto)
    {
      var devFromRepo = await _repo.Login(devForLoginDto.Email.ToLower(), devForLoginDto.Password);

      if (devFromRepo == null)
      {
        return Unauthorized();
      }

      var claims = new[]
      {
        new Claim(ClaimTypes.NameIdentifier, devFromRepo.Id.ToString()),
        new Claim(ClaimTypes.Name, devFromRepo.Email)
      };

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return Ok(new {
        token = tokenHandler.WriteToken(token)
      });
    }
  }
}
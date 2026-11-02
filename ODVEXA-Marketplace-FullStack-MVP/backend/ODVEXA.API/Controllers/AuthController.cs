using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ODVEXA.API.Data;
using ODVEXA.API.Models;
namespace ODVEXA.API.Controllers;
[ApiController][Route("api/auth")]
public class AuthController(AppDbContext db,IConfiguration config):ControllerBase{
 static string Hash(string password,byte[] salt){var key=Rfc2898DeriveBytes.Pbkdf2(password,salt,120000,HashAlgorithmName.SHA256,32);return Convert.ToBase64String(salt)+"."+Convert.ToBase64String(key);}
 static bool Verify(string password,string stored){var p=stored.Split('.');if(p.Length!=2)return false;return CryptographicOperations.FixedTimeEquals(Convert.FromBase64String(p[1]),Rfc2898DeriveBytes.Pbkdf2(password,Convert.FromBase64String(p[0]),120000,HashAlgorithmName.SHA256,32));}
 string Token(AppUser u){var jwt=config.GetSection("Jwt");var key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));var creds=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);var claims=new[]{new Claim(ClaimTypes.NameIdentifier,u.Id.ToString()),new Claim(ClaimTypes.Name,u.Name),new Claim(ClaimTypes.Email,u.Email),new Claim(ClaimTypes.Role,u.Role)};var token=new JwtSecurityToken(jwt["Issuer"],jwt["Audience"],claims,expires:DateTime.UtcNow.AddMinutes(double.Parse(jwt["ExpiresMinutes"]??"120")),signingCredentials:creds);return new JwtSecurityTokenHandler().WriteToken(token);}
 [HttpPost("register")] public async Task<IActionResult> Register(RegisterRequest r){if(string.IsNullOrWhiteSpace(r.Name)||r.Password.Length<8)return BadRequest(new{message="Name is required and password must be at least 8 characters."});var email=r.Email.Trim().ToLowerInvariant();if(await db.Users.AnyAsync(x=>x.Email==email))return Conflict(new{message="Email already registered."});var salt=RandomNumberGenerator.GetBytes(16);var u=new AppUser{Name=r.Name.Trim(),Email=email,PasswordHash=Hash(r.Password,salt),Role="Customer"};db.Users.Add(u);await db.SaveChangesAsync();return Ok(new{token=Token(u),user=new{id=u.Id,name=u.Name,email=u.Email,role=u.Role}});}
 [HttpPost("login")] public async Task<IActionResult> Login(LoginRequest r){var u=await db.Users.FirstOrDefaultAsync(x=>x.Email==r.Email.Trim().ToLowerInvariant());if(u is null||!Verify(r.Password,u.PasswordHash))return Unauthorized(new{message="Invalid email or password."});return Ok(new{token=Token(u),user=new{id=u.Id,name=u.Name,email=u.Email,role=u.Role}});}
 [HttpGet("me")] public IActionResult Me(){if(User.Identity?.IsAuthenticated!=true)return Unauthorized();return Ok(new{name=User.Identity.Name,email=User.FindFirst(ClaimTypes.Email)?.Value,role=User.FindFirst(ClaimTypes.Role)?.Value});}
}

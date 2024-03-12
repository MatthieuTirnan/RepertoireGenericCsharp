using FirstGenericRepository.Api.Request;
using FirstGenericRepository.Domain.Entity;
using FirstGenericRepository.Domain.Repository;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FirstGenericRepository.Api.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;

        public AuthController(IUnitOfWork unitOfWork,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }


        [HttpPost("register")]
        public ActionResult<User> Register([FromBody] UserRequest request)
        {
            var userAlreadyExist = _unitOfWork.User.GetUserByUsername(request.Username);
            if (userAlreadyExist != null)
            {
                return BadRequest("cette identifiant semble déjà utilisé");
            }

            try
            {
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                var user = new User
                {
                    Username = request.Username,
                    Password = passwordHash
                };

                _unitOfWork.User.Add(user);
                _unitOfWork.Save();
                return Ok(user);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e);
            }


        }

        [HttpGet("login")]

        public ActionResult<User> Login([FromBody] UserRequest request)
        {
            var userFromDb = _unitOfWork.User.GetUserByUsername(request.Username);
            if (userFromDb == null)
            {
                return BadRequest("User not found or wrong Password");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password, userFromDb.Password))
            {
                return BadRequest("User not found or wrong Password");
            }

            var token = CreateToken(userFromDb);

            return new OkObjectResult(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name , user.Username),
                new Claim(JwtClaimTypes.Role,user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value!));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credential);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

    }
}

using BackMultibanco.Data;
using BackMultibanco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackMultibanco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDTO request)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Email == request.email &&  c.Password == request.password);

            if (client == null)
            {
                return Unauthorized(new { mensagem = "Email or password incorrect!" });
            }

            // se encontrar, gerar token

            var token = GerarTokenJwt(client);

            // Devolve o Token à App
            return Ok(new
            {
                mensagem = "Logged in!",
                token = token
            });
        }

        // mtodo para gerar token

        private string GerarTokenJwt(Client client)
        {
           
        
            // configurar a chave
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // dados que leva
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, client.Id.ToString()), // O ID do cliente
                new Claim(JwtRegisteredClaimNames.Email, client.Email),       // O Email do cliente
                new Claim("Nome", client.Name)                                // O Nome
            };

            // validade de 1hora
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Validade
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    


    }

    public class LoginDTO
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}

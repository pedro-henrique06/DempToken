using DempToken.Domain;
using DempToken.Domain.Repositories;
using DempToken.Model;
using Microsoft.AspNetCore.Mvc;

namespace DempToken.Controller
{
    [ApiController]
    [Route("V1")]
    public class LoginController : ControllerBase
    {

        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync(string email, string password)
        {
            // Recuperar o usuario
            var user = await _userService.GetByLogin(email, password);

            // Verifica se o usuario existe
            if (user == null)
                return NotFound(new { message = "Usuario ou senha invalidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Ocultar a senha
            user.Password = "";

            // Retornar os dados

            return new
            {
                user = user,
                token = token
            };
        }
    }
}

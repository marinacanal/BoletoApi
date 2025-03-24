using BoletoApi.DTOs;
using BoletoApi.Services;
using DotNetEnv;
using Microsoft.AspNetCore.Mvc;

namespace BoletoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AutenticacaoController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("token")]
        public IActionResult GerarToken([FromBody] ClientCredentialsDTO credentials)
        {
            if (credentials.ClientId != Env.GetString("CLIENT_ID") || credentials.ClientSecret != Env.GetString("CLIENT_SECRET"))
                return Unauthorized("Client Id ou Client Secret inválidos!");

            var token = _tokenService.GerarToken(credentials.ClientId);
            return Ok(new { token });
        }
    }
}
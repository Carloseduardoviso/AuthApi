using Businnes.Helpers.Custons;
using Bussines.Data.Requests;
using Bussines.Data.Responses;
using Bussines.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]/")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(
            IUsuarioService usuarioService
        )
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AuthEntrar([FromBody] AuthRequest authRequest)
        {
            try
            {
                string senhaCriptografada = "";

                if (authRequest.Senha != "")
                {
                    senhaCriptografada = CriptografiaPassword.Execute(authRequest.Senha);
                }

                var usuarioLogin = await _usuarioService.GetAuthAsync(x => x.Email.Equals(authRequest.Email) && x.Senha.Equals(senhaCriptografada));

                var resultado = new ResultDataResponse<AuthResponse>(
                     false,
                     200,
                     usuarioLogin,
                     "Sucesso ao realizar o login"
                  );

                return  Ok(resultado);
            }
            catch (HttpRequestException ex) when (ex.StatusCode.HasValue)
            {
                var statusCode = (int)ex.StatusCode.Value;

                var resultado = new ResultDataResponse<AuthResponse>(
                       false,
                       statusCode,
                       null,
                       ex.Message
                    );

                return BadRequest(resultado);
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using QueroComer.Utils;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _service;
        private readonly IValidator<Login> _validator;

        public AuthenticationController(IAuthenticationService service,
                                        IValidator<Login> validator)
        {
            _service = service;
            _validator = validator;
        }

        [HttpPost, Route("login")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            try
            {
                var validator = await _validator.ValidateAsync(login);
                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                RespostaLogin LoginResponse = await _service.LoginAsync(login);

                if(LoginResponse.StatusCode == EStatusCode.Unauthorized)
                    return Unauthorized("Email ou senha incorretos");

                if (LoginResponse.StatusCode == EStatusCode.BadRequest)
                    return BadRequest("Email específicado não está cadastrado");

                return Ok(LoginResponse);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

    }
}

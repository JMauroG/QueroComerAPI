using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FluentValidation;
using QueroComer.Utils;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.DTO.User;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDTO> _validator;

        public UsersController(IUserService service,
                               IMapper mapper,
                               IValidator<CreateUserDTO> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{Id}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperaUsuariosAsync(string Id)
        {
            try
            {
                if (Id == null)
                    return BadRequest("Id eh obrigatorio");

                IdentityUser user = await _service.RetornaUsuarioPorIdAsync(Id);

                if (user == null)
                    return NotFound();

                var readUserDTO = _mapper.Map<ReadUserDTO>(user);
                return Ok(readUserDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Cadastra um usuario
        /// </summary>
        /// <param name="createUserDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarUsuarioAsync([FromBody] CreateUserDTO createUserDTO)
        {
            try
            {
                //var validator = await _validator.ValidateAsync(createUserDTO);
                //if (!validator.IsValid)
                //    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                //IdentityUser user = await _service.CadastrarUsuarioAsync(createUserDTO);

                //return Ok(new { Id = user.Id });




                var validator = await _validator.ValidateAsync(createUserDTO);
                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });
                Usuario usuario = _mapper.Map<Usuario>(createUserDTO);
                IdentityUser novoUser = _service.CreateIdentityUser(usuario);
                Resposta resposta = await _service.CadastrarUsuarioAsync(novoUser);
                if (!resposta.Sucesso)
                    return BadRequest(resposta.ListaDeErros);

                IdentityUser userCriado = await _service.RetornaUsuarioPorEmailAsync(createUserDTO.Email);

                return Ok(new { Id = userCriado.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

    }
}

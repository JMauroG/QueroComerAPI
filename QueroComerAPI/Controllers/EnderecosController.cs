using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueroComer.DTO.Endereco;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Utils;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly IValidator<CreateEnderecoDTO> _validator;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Construtor de EnderecoController
        /// </summary>
        /// <param name="service"></param>
        /// <param name="validator"></param>
        /// <param name="mapper"></param>
        public EnderecosController(IEnderecoService service,
                                   IValidator<CreateEnderecoDTO> validator,
                                   IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        ///     Retorna todos os enderecos de um usuario
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <returns></returns>
        [HttpGet("Usuario/{IdUsuario}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarEnderecosPorUsuarioAsync(string IdUsuario)
        {
            try
            {
                if (IdUsuario == string.Empty || Guid.Parse(IdUsuario) == Guid.Empty)
                    return BadRequest("Id Invalido");

                List<Endereco> enderecos = await _service.RecuperarEnderecosPorUsuarioAsync(IdUsuario);

                if (enderecos.Count == 0)
                    return NotFound("Nenhum endereco cadastrado");

                return Ok(enderecos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna um Endereco utilizando um id de Endereco
        /// </summary>
        /// <param name="IdEndereco"></param>
        /// <returns></returns>
        [HttpGet("{IdEndereco}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarEnderecoPorIdAsync(Guid IdEndereco)
        {
            try
            {
                if (IdEndereco == Guid.Empty)
                    return BadRequest("Id Invalido");

                Endereco endereco = await _service.RecuperarEnderecoPorIdAsync(IdEndereco);

                if (endereco == null)
                    return NotFound("Nenhum endereco cadastrado");

                return Ok(endereco);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Cadastra um endereco novo
        /// </summary>
        /// <param name="IdUsuario"></param>
        /// <param name="createEnderecoDTO"></param>
        /// <returns></returns>
        [HttpPost("{IdUsuario}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarEnderecoAsync(string IdUsuario, [FromBody] CreateEnderecoDTO createEnderecoDTO)
        {
            try
            {
                var validator = await _validator.ValidateAsync(createEnderecoDTO);

                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (IdUsuario == string.Empty)
                    return BadRequest("Id Invalido");


                Endereco endereco = _mapper.Map<Endereco>(createEnderecoDTO);

                var enderecoCadastrado = await _service.CadastrarEnderecoAsync(IdUsuario, endereco);

                return Ok(new { Id = enderecoCadastrado.Id });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }


    }
}
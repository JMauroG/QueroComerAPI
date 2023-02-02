using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using QueroComer.DTO.Restaurante;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;
using QueroComer.Utils;

namespace QueroComer.Controllers
{
    /// <summary>
    ///     Responsavel por controllar os endpoints de Restaurante
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly IRestauranteService _service;
        private readonly IEnderecoService _enderecoService;
        private readonly IValidator<CreateRestauranteDTO> _validator;
        private readonly IValidator<ReadCategoriaRestauranteDTO> _validatorCategoria;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Construtor de RestauranteController
        /// </summary>
        /// <param name="service"> Service de Restaurante </param>
        /// <param name="enderecoService"> Service de Endereco </param>
        /// <param name="validator"> Validator para o DTO de Criar Restaurante </param>
        /// <param name="mapper"> AutoMapper </param>
        /// <param name="validatorCategoria"> Validator para o DTO de Categoria</param>
        public RestaurantesController(IRestauranteService service,
                                      IEnderecoService enderecoService,
                                      IValidator<CreateRestauranteDTO> validator,
                                      IMapper mapper,
                                      IValidator<ReadCategoriaRestauranteDTO> validatorCategoria)
        {
            _service = service;
            _enderecoService = enderecoService;
            _validator = validator;
            _mapper = mapper;
            _validatorCategoria = validatorCategoria;
        }

        /// <summary>
        ///     Retorna um Restaurante utilizando um id de Restaurante
        /// </summary>
        /// <param name="IdRestaurante"></param>
        /// <returns></returns>
        [HttpGet("{IdRestaurante}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarRestaurantePorIDAsync(Guid IdRestaurante)
        {
            try
            {
                if (IdRestaurante == Guid.Empty)
                    return BadRequest("Id Inválido");

                Restaurante restaurante = await _service.RecuperarRestaurantePorIdAsync(IdRestaurante);

                if (restaurante == null)
                    return NotFound("Restaurante não encontrado");

                return Ok(restaurante);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna uma lista de restaurantes baseada em uma categoria selecionada
        /// </summary>
        /// <param name="categoriaDto"></param>
        /// <returns></returns>
        [HttpGet("Categoria")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarRestaurantePorCategoriaAsync([FromBody]ReadCategoriaRestauranteDTO categoriaDto)
        {
            try
            {
                var validatorCategoria = await _validatorCategoria.ValidateAsync(categoriaDto);

                if (!validatorCategoria.IsValid)
                    return BadRequest(ValidatorUtils.ListarErros(validatorCategoria.Errors));

                List<Restaurante> restaurantes = await _service.RecuperarRestaurantesPorCategoriaAsync(categoriaDto.Categoria);

                if (restaurantes.Count == 0)
                    return NotFound("Nenhum restaurante encontrado nesta categoria");

                return Ok(restaurantes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Cadastra um Restaurante
        /// </summary>
        /// <param name="createRestauranteDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarRestauranteAsync([FromBody] CreateRestauranteDTO createRestauranteDTO)
        {
            try
            {
                var validator = await _validator.ValidateAsync(createRestauranteDTO);

                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (!await _enderecoService.VerificarSeEnderecoExiste(createRestauranteDTO.EnderecoId))
                    return BadRequest("Endereco passado nao existe");

                Restaurante restaurante = _mapper.Map<Restaurante>(createRestauranteDTO);
                var restauranteCadastrado = await _service.CadastrarRestauranteAsync(restaurante);

                if (restauranteCadastrado == null)
                    return BadRequest();

                return Ok(new { id = restauranteCadastrado.Id });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }
    }
}

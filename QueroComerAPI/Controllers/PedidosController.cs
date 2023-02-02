using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueroComer.DTO.Pedido;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Services;
using QueroComer.Utils;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IPedidoService _service;
        private readonly IValidator<CreatePedidoDTO> _validator;
        private readonly IValidator<UpdatePedidoDTO> _validatorUpdate;
        private readonly IMapper _mapper;

        public PedidosController(IEnderecoService enderecoService,
                                 IPedidoService service,
                                 IValidator<CreatePedidoDTO> validator,
                                 IValidator<UpdatePedidoDTO> validatorUpdate,
                                 IMapper mapper)
        {
            _validator = validator;
            _validatorUpdate = validatorUpdate;
            _mapper = mapper;
            _enderecoService = enderecoService;
            _service = service;
        }

        /// <summary>
        ///     Cadastra um Pedido
        /// </summary>
        /// <param name="createPedidoDTO"></param>
        /// <returns></returns>
        [HttpPost, Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarPedidoAsync([FromBody] CreatePedidoDTO createPedidoDTO)
        {
            try
            {
                var validator = await _validator.ValidateAsync(createPedidoDTO);

                if(!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (!await _enderecoService.VerificarSeEnderecoExiste(createPedidoDTO.EnderecoId))
                    return BadRequest("Endereço inválido");

                Pedido pedido = _mapper.Map<Pedido>(createPedidoDTO);
                var pedidoCadastrado = await _service.CadastrarPedidoAsync(pedido);

                if (pedidoCadastrado == null)
                    return BadRequest();

                ReadPedidoDTO readPedidoDTO = _mapper.Map<ReadPedidoDTO>(pedidoCadastrado);

                return Ok(readPedidoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna um pedido a partir do seu Id
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        [HttpGet("{IdPedido}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarPedidoPorIdAsync(Guid IdPedido)
        {
            try
            {
                if (IdPedido == Guid.Empty)
                    return BadRequest("Id inválido");

                Pedido pedido = await _service.RecuperarPedidoPorIdAsync(IdPedido);

                if(pedido == null) 
                    return NotFound("Pedido não encontrado");

                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna uma lista de pedidos a partir de um Id de usuário
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        [HttpGet("User/{IdUser}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarPedidosPorUserAsync(string IdUser)
        {
            try
            {
                if (IdUser == String.Empty)
                    return BadRequest("Id Inválido");

                List<Pedido> pedidos = await _service.RecuperarPedidosPorUserAsync(IdUser);

                if (pedidos.Count == 0)
                    return NotFound("Usuário não efetou pedidos");

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Atualiza o Status de um pedido
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="updatePedidoDTO"></param>
        /// <returns></returns>
        [HttpPut("{IdPedido}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarStatusPedidoAsync(Guid IdPedido, [FromBody] UpdatePedidoDTO updatePedidoDTO)
        {

            try
            {
                var validator = await _validatorUpdate.ValidateAsync(updatePedidoDTO);

                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (IdPedido != updatePedidoDTO.Id)
                    return BadRequest("Id inválido");

                if (updatePedidoDTO.Status == EStatusPedido.Aberto)
                    return BadRequest("Não é possível fazer está alteração");

                Pedido pedido = await _service.RecuperarPedidoPorIdAsync(IdPedido);

                if (pedido == null)
                    return NotFound("Pedido não encontrado");

                if(pedido.Status == EStatusPedido.Concluido || pedido.Status == EStatusPedido.Cancelado)
                    return BadRequest("Esse pedido já foi concluído ou cancelado");

                pedido.Status = updatePedidoDTO.Status;
                await _service.AtualizarStatusPedidoAsync(pedido);

                return Ok("O status do pedido foi atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }

        }
    }
}

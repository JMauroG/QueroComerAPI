using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueroComer.DTO.PedidoProduto;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Enumerables;
using QueroComer.Entidades.Interfaces;
using QueroComer.Utils;
using System.ComponentModel.DataAnnotations;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PedidosProdutosController : ControllerBase
    {
        private readonly IPedidoProdutoService _service;
        private readonly IPedidoService _servicePedido;
        private readonly IValidator<UpdatePedidoProdutoDTO> _validatorUpdate;
        private readonly IValidator<CreatePedidoProdutoDTO> _validator;
        private readonly IMapper _mapper;

        /// <summary>
        ///     Construtor de PedidosProdutosController
        /// </summary>
        /// <param name="service">Serviço de PedidoProduto</param>
        /// <param name="servicePedido">Serviço de Pedido</param>
        /// <param name="validatorUpdate">Validador Fluente de UpdatePredidoProdutoDTO</param>
        /// <param name="validator">Validador Fluent de CreatePedidoProdutoDTO</param>
        /// <param name="mapper">AutoMapper</param>
        public PedidosProdutosController(IPedidoProdutoService service,
                                         IPedidoService servicePedido,
                                         IValidator<UpdatePedidoProdutoDTO> validatorUpdate,
                                         IValidator<CreatePedidoProdutoDTO> validator,
                                         IMapper mapper)
        {
            _service = service;
            _servicePedido = servicePedido;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
            _mapper = mapper;
        }

        /// <summary>
        ///     Cadastra um PedidoProduto
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="createPedidoProdutoDTO"></param>
        /// <returns></returns>
        [HttpPost("{IdPedido}"),Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarPedidoProduto(Guid IdPedido, [FromBody] CreatePedidoProdutoDTO createPedidoProdutoDTO)
        {
            try
            {
                var validator = await _validator.ValidateAsync(createPedidoProdutoDTO);
                if(!validator.IsValid)
                    return BadRequest(new {Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (!IdPedido.Equals(createPedidoProdutoDTO.PedidoId))
                    return BadRequest("Id Inválido");

                PedidoProduto pedidoProduto = _mapper.Map<PedidoProduto>(createPedidoProdutoDTO);

                var pedidoProdutoCadastrado = await _service.CadastrarPedidoProdutoAsync(pedidoProduto);

                return Ok(new { Id = pedidoProdutoCadastrado.Id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Atualiza a quantidade de um PedidoProduto
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <param name="updatePedidoProdutoDTO"></param>
        /// <returns></returns>
        [HttpPut("{IdPedido}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarQuantidadePedidoProdutoAsync(Guid IdPedido, [FromBody] UpdatePedidoProdutoDTO updatePedidoProdutoDTO)
        {
            try
            {
                var validator = await _validatorUpdate.ValidateAsync(updatePedidoProdutoDTO);
                if(!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                var pedidoProduto = await _service.RecuperarPedidoProdutoPorIdAsync(updatePedidoProdutoDTO.Id);

                if (pedidoProduto == null)
                    return NotFound("PedidoProduto não encontrado");

                if (pedidoProduto.PedidoId != IdPedido)
                    return BadRequest("Id de Pedido é inválido");

                pedidoProduto.Quantidade = updatePedidoProdutoDTO.Quantidade;

                await _service.AtualizarQuantidadePedidoProdutoAsync(pedidoProduto);

                return Ok("PedidoProduto atualizado com sucesso");
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna um PedidoProduto por seu Id
        /// </summary>
        /// <param name="IdPedidoProduto"></param>
        /// <returns></returns>
        [HttpGet("{IdPedidoProduto}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarPedidoProdutoPorIdAsync(Guid IdPedidoProduto)
        {
            try
            {
                if(IdPedidoProduto.Equals(Guid.Empty))
                    return BadRequest("Id inválido");

                PedidoProduto pedidoProduto = await _service.RecuperarPedidoProdutoPorIdAsync(IdPedidoProduto);

                if (pedidoProduto == null)
                    return NotFound("Não foi encontrado");

                return Ok(pedidoProduto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retorna os produtos de um pedido a partir de um IdPedido
        /// </summary>
        /// <param name="IdPedido"></param>
        /// <returns></returns>
        [HttpGet("Pedido/{IdPedido}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarPedidoProdutoPorPedidoAsync(Guid IdPedido)
        {
            try
            {
                if(IdPedido.Equals(Guid.Empty))
                    return BadRequest("Id Inválido");

                List<PedidoProduto> pedidoProdutos = await _service.RecuperarPedidoProdutosPorPedidoAsync(IdPedido);

                if (pedidoProdutos.Count == 0)
                    return NotFound("Pedido inválido");

                return Ok(pedidoProdutos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }
        
        /// <summary>
        ///     Deleta um PedidoProduto
        /// </summary>
        /// <param name="IdPedido">Id do pedido a qual o PedidoProduto Pertence</param>
        /// <param name="pedidoProduto">PedidoProduto que sera excluidos</param>
        /// <returns></returns>
        [HttpDelete("{IdPedido}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoverPedidoProdutoAsync(Guid IdPedido, [FromBody] DeletePedidoProdutoDTO deletePedidoProdutoDTO)
        {
            try
            {
                PedidoProduto pedidoProduto = _mapper.Map<PedidoProduto>(deletePedidoProdutoDTO);

                if (IdPedido != pedidoProduto.PedidoId)
                    return BadRequest("Id de pedido inválido");

                Pedido pedido = await _servicePedido.RecuperarPedidoPorIdAsync(IdPedido);

                PedidoProduto check = await _service.RecuperarPedidoProdutoPorIdAsync(pedidoProduto.Id);

                if (check == null)
                    return NotFound("O item não encontrado");

                if (pedido.Status == EStatusPedido.Concluido ||
                    pedido.Status == EStatusPedido.Cancelado ||
                    pedido.Status == EStatusPedido.ACaminho)
                    return BadRequest("Não é possível fazer está alteração na etapa atual do pedido");

                await _service.RemoverPedidoProdutoAsync(pedidoProduto);
                return Ok("O item removido do pedido com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

    }
}

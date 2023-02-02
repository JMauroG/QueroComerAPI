using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueroComer.DTO.Produto;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Utils;

namespace QueroComer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        private readonly IValidator<CreateProdutoDTO> _validator;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoService service,
                                  IValidator<CreateProdutoDTO> validator,
                                  IMapper mapper)
        {
            _service = service;
            _validator = validator;
            _mapper = mapper;
        }

        /// <summary>
        ///     Cadastrar um produto
        /// </summary>
        /// <param name="IdRestaurante"></param>
        /// <param name="createProdutoDTO"></param>
        /// <returns></returns>
        [HttpPost("{IdRestaurante}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarProduto(Guid IdRestaurante, [FromBody] CreateProdutoDTO createProdutoDTO)
        {
            try
            {
                var validator = await _validator.ValidateAsync(createProdutoDTO);

                if (!validator.IsValid)
                    return BadRequest(new { Erros = ValidatorUtils.ListarErros(validator.Errors) });

                if (!IdRestaurante.Equals(createProdutoDTO.RestauranteId))
                    return BadRequest("Id Inválido");

                Produto produto = _mapper.Map<Produto>(createProdutoDTO);

                var produtoCadastrado = await _service.CadastrarProdutoAsync(produto);

                return Ok(new { Id = produtoCadastrado.Id });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        ///     Retornar um produto utilizando um Id de Produto
        /// </summary>
        /// <param name="IdProduto"></param>
        /// <returns></returns>
        [HttpGet("{IdProduto}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarProdutoPorIdAsync(Guid IdProduto)
        {
            try
            {
                if(IdProduto.Equals(""))
                    return BadRequest("Id inválido");

                Produto produto = await _service.RetornarProdutoPorIdAsync(IdProduto);

                if (produto == null)
                    return NotFound("Nenhum produto encontrar");

                return Ok(produto);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Retorna uma lista de produtos referente a um restaurante
        /// </summary>
        /// <param name="IdRestaurante"></param>
        /// <returns></returns>
        [HttpGet("Restaurante/{IdRestaurante}"), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RecuperarProdutoPorRestauranteAsync(Guid IdRestaurante)
        {
            try
            {
                if (IdRestaurante.Equals(""))
                    return BadRequest("Id Inválido");

                List<Produto> produtos = await _service.RetornarProdutosPorRestauranteAsync(IdRestaurante);

                if (produtos.Count == 0)
                    return NotFound("Restaurante não tem produtos disponíveis");

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Mensagem = ex.Message });
            }
        }
    }
}

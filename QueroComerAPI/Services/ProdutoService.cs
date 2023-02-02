using AutoMapper;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Produto> CadastrarProdutoAsync(Produto produto)
        {
            try
            {
                await _repository.CadastrarProdutoAsync(produto);

                return produto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Produto> RetornarProdutoPorIdAsync(Guid IdProduto)
        {
            try
            {
                return await _repository.RecuperarProdutoPorIdAsync(IdProduto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Produto>> RetornarProdutosPorRestauranteAsync(Guid IdRestaurante)
        {
            try
            {
                List<Produto> produtos = await _repository.RecuperarProdutosPorRestauranteAsync(IdRestaurante);

                return produtos;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

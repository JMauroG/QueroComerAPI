using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QueroComer.DTO.Endereco;
using QueroComer.DTO.Pedido;
using QueroComer.DTO.PedidoProduto;
using QueroComer.DTO.Produto;
using QueroComer.DTO.Restaurante;
using QueroComer.DTO.User;
using QueroComer.Entidades.Entidades;

namespace QueroComer.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>()
                .ReverseMap();
            
            CreateMap<ReadUserDTO, IdentityUser>()
                .ReverseMap();

            CreateMap<CreateRestauranteDTO, Restaurante>()
                .ReverseMap();
            
            CreateMap<Usuario, CreateUserDTO>()
                .ReverseMap();

            CreateMap<Produto, CreateProdutoDTO>()
                .ReverseMap();

            CreateMap<Pedido, CreatePedidoDTO>()
                .ReverseMap();

            CreateMap<Pedido, ReadPedidoDTO>()
                .ReverseMap();
           
            CreateMap<PedidoProduto, CreatePedidoProdutoDTO>()
                .ReverseMap();

            CreateMap<DeletePedidoProdutoDTO, PedidoProduto>()
                .ReverseMap();
        }
    }
}

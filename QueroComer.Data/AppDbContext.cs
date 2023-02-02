using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;

namespace QueroComer.Data
{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> context) : base(context)
        {
        }

        public DbSet<IdentityUser> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoProduto> PedidosProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

    }
}

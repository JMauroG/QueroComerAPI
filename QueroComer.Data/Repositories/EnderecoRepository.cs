using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly AppDbContext _context;

        public EnderecoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CadastrarEnderecoAsync(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<Endereco> RecuperarEnderecoPorIdAsync(Guid IdEndereco)
        {
            return await _context.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id.Equals(IdEndereco));
        }

        public async Task<List<Endereco>> RecuperarEnderecosPorUsuarioAsync(IdentityUser user)
        {
            return await _context.Enderecos.Include(x => x.Usuario)
                .Where(x => x.Usuario.Id.Equals(user.Id))
                .ToListAsync();
        }

        public IEnumerable<Endereco> GetEnumerable()
        {
            return _context.Enderecos;
        }


    }
}

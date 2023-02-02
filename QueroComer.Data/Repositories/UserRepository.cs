using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        ///<summary>
        ///    Retorna um usuario usando seu email
        ///</summary>
        ///<returns>User</returns>
        ///<param name="email">User Email</param>
        public async Task<IdentityUser> RetornaUsuarioPorEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));
        }

        public async Task<IdentityUser> RetornaUsuarioPorIdAsync(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
        public IEnumerable<IdentityUser> GetEnumerable()
        {
            return _context.Users;
        }
    }
}

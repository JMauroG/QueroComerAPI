using Microsoft.AspNetCore.Identity;
using QueroComer.Utils;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;
using QueroComer.Entidades.Enumerables;

namespace QueroComer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<IdentityUser> _userManager;


        public UserService(IUserRepository repository,
                           UserManager<IdentityUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<IdentityUser> RetornaUsuarioPorIdAsync(string Id)
        {
            try
            {
                return await _repository.RetornaUsuarioPorIdAsync(Id);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IdentityUser> RetornaUsuarioPorEmailAsync(string email)
        {
            return await _repository.RetornaUsuarioPorEmailAsync(email);
        }
        public async Task<Resposta> CadastrarUsuarioAsync(IdentityUser novoUser)
        {
            try
            {
                IdentityResult result = await _userManager.CreateAsync(novoUser);
                if (result.Succeeded)
                {
                    return new Resposta
                    {
                        Mensagem = "Usuário cadastrado com sucesso",
                        StatusCode = EStatusCode.Created,
                        Sucesso = true
                    };
                }

                List<string> erros = ValidatorUtils.ListarErros(result.Errors.ToList());

                return new Resposta
                {
                    Mensagem = "Ocorreu um erro ao cadastrar um novo usuario",
                    StatusCode = EStatusCode.BadRequest,
                    Sucesso = false,
                    ListaDeErros = erros
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IdentityUser CreateIdentityUser(Usuario usuario)
        {
            try
            {
                IdentityUser novoUser = new IdentityUser
                {
                    Email = usuario.Email,
                    UserName = usuario.Nome
                };
                novoUser.PasswordHash = _userManager.PasswordHasher.HashPassword(novoUser, usuario.Password);

                return novoUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

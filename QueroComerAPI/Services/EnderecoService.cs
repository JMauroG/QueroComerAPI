using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QueroComer.Entidades.Entidades;
using QueroComer.Entidades.Interfaces;

namespace QueroComer.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public EnderecoService(IEnderecoRepository repository,
                               IUserRepository userRepository,
                               IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Endereco> CadastrarEnderecoAsync(string IdUsuario, Endereco endereco)
        {
            try
            {
                IdentityUser user = await _userRepository.RetornaUsuarioPorIdAsync(IdUsuario);
                endereco.Usuario = user;
                await _repository.CadastrarEnderecoAsync(endereco);

                return endereco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Endereco> RecuperarEnderecoPorIdAsync(Guid IdEndereco)
        {
            try
            {
                return await _repository.RecuperarEnderecoPorIdAsync(IdEndereco);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Endereco>> RecuperarEnderecosPorUsuarioAsync(string IdUsuario)
        {
            try
            {
                IdentityUser user = await _userRepository.RetornaUsuarioPorIdAsync(IdUsuario);
                List<Endereco> enderecos = await _repository.RecuperarEnderecosPorUsuarioAsync(user);
                
                return enderecos;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        public async Task<bool> VerificarSeEnderecoExiste(Guid IdEndereco)
        {
            try
            {
                var endereco = await _repository.RecuperarEnderecoPorIdAsync(IdEndereco);
                if(endereco != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

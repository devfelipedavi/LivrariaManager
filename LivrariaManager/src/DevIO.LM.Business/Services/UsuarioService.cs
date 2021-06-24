using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IEnderecoRepository enderecoRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _enderecoRepository = enderecoRepository;
        }


        public async Task Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)
                || !ExecutarValidacao(new EnderecoValidation(), usuario.Endereco)) return;

            if (_usuarioRepository.Buscar(f => f.Nome == usuario.Nome).Result.Any())
            {
                Notificar("Já existe um usuário com este nome infomado.");
                return;
            }

            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            if (_usuarioRepository.Buscar(f => f.Nome == usuario.Nome && f.Id != usuario.Id).Result.Any())
            {
                Notificar("Já existe um usuário com este nome infomado.");
                return;
            }

            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_usuarioRepository.ObterUsuarioAlugueisEndereco(id).Result.Alugueis.Any())
            {
                Notificar("O usuário possui emprestimo de livros cadastrados!");
                return;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorUsuario(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }

    }
}

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

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;          
        }


        public async Task Adicionar(Usuario usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

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
        
       

        public async Task Remover(Guid id)
        {
            if (_usuarioRepository.ObterUsuarioAlugueis(id).Result.Alugueis.Any())
            {
                Notificar("O usuário possui emprestimo de livros cadastrados!");
                return;
            } 

            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();            
        }

    }
}

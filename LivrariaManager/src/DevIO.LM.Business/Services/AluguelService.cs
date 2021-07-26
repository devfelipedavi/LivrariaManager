using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Services
{
    public class AluguelService : BaseService , IAluguelService
    {
        private readonly IAluguelRepository _aluguelRepository;


        public AluguelService(IAluguelRepository aluguelRepository,
                                 INotificador notificador) : base(notificador)
        {
            _aluguelRepository = aluguelRepository;
        }

        public async Task Adicionar(Aluguel aluguel)
        {
            if (!ExecutarValidacao(new AluguelValidation(), aluguel)) return;

            if (_aluguelRepository.Buscar(f => f.Livro == aluguel.Livro).Result.Any())
            {
                Notificar("Já existe um aluguel com este livro infomado.");
                return;
            }

            if (_aluguelRepository.Buscar(f => f.Usuario == aluguel.Usuario).Result.Any())
            {
                Notificar("Já existe um aluguel com este usuário infomado.");
                return;
            }

            await _aluguelRepository.Adicionar(aluguel);
        }

        public async Task Atualizar(Aluguel aluguel)
        {
            if (!ExecutarValidacao(new AluguelValidation(), aluguel)) return;

            if (_aluguelRepository.Buscar(f => f.Livro == aluguel.Livro && f.Id != aluguel.Id).Result.Any())
            {
                Notificar("Já existe um aluguel com este livro infomado.");
                return;
            }

            if (_aluguelRepository.Buscar(f => f.Usuario == aluguel.Usuario && f.Id != aluguel.Id).Result.Any())
            {
                Notificar("Já existe um aluguel com este usuario infomado.");
                return;
            }

            await _aluguelRepository.Atualizar(aluguel);
        }

        public async Task Remover(Guid id)
        {
            if (_aluguelRepository.ObterAluguelLivros(id).Result.Livros.Any())
            {
                Notificar("O aluguel possui livros cadastrados!");
                return;
            }

            if (_aluguelRepository.ObterAluguelUsuarios(id).Result.Usuarios.Any())
            {
                Notificar("O aluguel possui livros cadastrados!");
                return;
            }

            await _aluguelRepository.Remover(id);
        }

        public void Dispose()
        {
            _aluguelRepository?.Dispose();            
        }
    }
}

using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Services
{
    public class EditoraService : BaseService, IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;
        

        public EditoraService(IEditoraRepository editoraRepository,                             
                              INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;           
        }

        public async Task Adicionar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)) return;

            if (_editoraRepository.Buscar(f => f.Nome == editora.Nome).Result.Any())
            {
                Notificar("Já existe uma editora com este nome infomado.");
                return;
            }

            await _editoraRepository.Adicionar(editora);
        }

        public async Task Atualizar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)) return;

            if (_editoraRepository.Buscar(f => f.Nome == editora.Nome && f.Id != editora.Id).Result.Any())
            {
                Notificar("Já existe uma editora com este nome infomado.");
                return;
            }

            await _editoraRepository.Atualizar(editora);
        }        

        public async Task Remover(Guid id)
        {
            if (_editoraRepository.ObterEditoraLivros(id).Result.Livros.Any())
            {
                Notificar("A Editora possui livros cadastrados!");
                return;
            }
            

            await _editoraRepository.Remover(id);
        }

        public void Dispose()
        {
            _editoraRepository?.Dispose();            
        }
    }
}

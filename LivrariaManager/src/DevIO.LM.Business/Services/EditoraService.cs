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
        private readonly IEnderecoRepository _enderecoRepository;

        public EditoraService(IEditoraRepository editoraRepository,
                              IEnderecoRepository enderecoRepository,
                              INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _enderecoRepository = enderecoRepository;
        }

        public async Task Adicionar(Editora editora)
        {
            if (!ExecutarValidacao(new EditoraValidation(), editora)
                || !ExecutarValidacao(new EnderecoValidation(), editora.Endereco)) return;

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

        public async Task AtualizarEndereco(Endereco endereco)
        {
            if (!ExecutarValidacao(new EnderecoValidation(), endereco)) return;

            await _enderecoRepository.Atualizar(endereco);
        }

        public async Task Remover(Guid id)
        {
            if (_editoraRepository.ObterEditoraLivrosEndereco(id).Result.Livros.Any())
            {
                Notificar("A Editora possui livros cadastrados!");
                return;
            }

            var endereco = await _enderecoRepository.ObterEnderecoPorEditora(id);

            if (endereco != null)
            {
                await _enderecoRepository.Remover(endereco.Id);
            }

            await _editoraRepository.Remover(id);
        }

        public void Dispose()
        {
            _editoraRepository?.Dispose();
            _enderecoRepository?.Dispose();
        }
    }
}

using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IEditoraService : IDisposable
    {
        Task Adicionar(Editora editora);
        Task Atualizar(Editora editora);
        Task Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}

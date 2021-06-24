using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface ILivroService : IDisposable
    {
        Task Adicionar(Livro livro);
        Task Atualizar(Livro livro);
        Task Remover(Guid id);
    }
}

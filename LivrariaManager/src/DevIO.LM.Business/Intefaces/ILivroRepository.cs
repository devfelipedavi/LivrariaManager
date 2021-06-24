using DevIO.LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IEnumerable<Livro>> ObterLivrosPorEditora(Guid editoraId);
        Task<IEnumerable<Livro>> ObterLivrosEditoras();
        Task<Livro> ObterLivroEditora(Guid id);
    }
}
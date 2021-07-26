using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> ObterEditora(Guid id);
        Task<Editora> ObterEditoraLivros(Guid id);
    }
}

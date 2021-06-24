using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
        Task<Editora> ObterEditoraEndereco(Guid id);
        Task<Editora> ObterEditoraLivrosEndereco(Guid id);
    }
}

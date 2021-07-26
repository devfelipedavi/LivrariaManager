using DevIO.LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuario(Guid id);
        Task<Usuario> ObterUsuarioAlugueis(Guid id);
    }
}

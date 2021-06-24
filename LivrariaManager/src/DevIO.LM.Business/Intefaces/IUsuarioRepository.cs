using DevIO.LM.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ObterUsuarioEndereco(Guid id);
        Task<Usuario> ObterUsuarioAlugueisEndereco(Guid id);
    }
}

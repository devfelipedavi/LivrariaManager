using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IAluguelRepository : IRepository<Aluguel>
    {
        Task<Aluguel> ObterAluguel(Guid id);
        Task<Aluguel> ObterAluguelLivros(Guid id);
        Task<Aluguel> ObterAluguelUsuarios(Guid id);
    }
}

using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IAluguelService : IDisposable
    {
        Task Adicionar(Aluguel aluguel);
        Task Atualizar(Aluguel aluguel);
        Task Remover(Guid id);
    }
}

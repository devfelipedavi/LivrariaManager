using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Remover(Guid id);

        Task AtualizarEndereco(Endereco endereco);
    }
}

using DevIO.LM.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Business.Intefaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorEditora(Guid editoraId);
        Task<Endereco> ObterEnderecoPorUsuario(Guid usuarioId);
    }
}

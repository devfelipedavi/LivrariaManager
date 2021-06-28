using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Usuario> ObterUsuario(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()                
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Usuario> ObterUsuarioAlugueis(Guid id)
        {
            return await Db.Usuarios.AsNoTracking()
                .Include(c => c.Alugueis)                
                .FirstOrDefaultAsync(c => c.Id == id);
        }        
    }
}

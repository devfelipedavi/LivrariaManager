using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Data.Repository
{
    public class AluguelRepository : Repository<Aluguel>, IAluguelRepository
    {
        public AluguelRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Aluguel> ObterAluguel(Guid id)
        {
            return await Db.Alugueis.AsNoTracking()
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluguel> ObterAluguelLivros(Guid id)
        {
            return await Db.Alugueis.AsNoTracking()
                .Include(c => c.Livros)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Aluguel> ObterAluguelUsuarios(Guid id)
        {
            return await Db.Alugueis.AsNoTracking()
                .Include(c => c.Usuarios)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

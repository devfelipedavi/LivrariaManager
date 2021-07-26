using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.LM.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(MeuDbContext context) : base(context) { }

        public async Task<Livro> ObterLivroEditora(Guid id)
        {
            return await Db.Livros.AsNoTracking().Include(f => f.Editora)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Livro>> ObterLivrosEditoras()
        {
            return await Db.Livros.AsNoTracking().Include(f => f.Editora)
                .OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Livro>> ObterLivrosPorEditora(Guid editoraId)
        {
            return await Buscar(p => p.EditoraId == editoraId);
        }
    }
}

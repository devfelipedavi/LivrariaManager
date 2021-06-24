using DevIO.LM.Business.Intefaces;
using DevIO.LM.Business.Models;
using DevIO.LM.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevIO.LM.Data.Repository
{
    public class EditoraRepository : Repository<Editora>, IEditoraRepository
    {
        public EditoraRepository(MeuDbContext context) : base(context)
        {
        }

        public async Task<Editora> ObterEditoraEndereco(Guid id)
        {
            return await Db.Editoras.AsNoTracking()
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }        

        public async Task<Editora> ObterEditoraLivrosEndereco(Guid id)
        {
            return await Db.Editoras.AsNoTracking()
                .Include(c => c.Livros)
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

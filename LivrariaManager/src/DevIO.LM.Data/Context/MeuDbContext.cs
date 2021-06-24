using DevIO.LM.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevIO.LM.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Aluguel> Alugueis { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        

        //??
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAluguel") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataAluguel").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataAluguel").IsModified = false;
            //    }
            //}

            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDevolucao") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataDevolucao").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataDevolucao").IsModified = false;
            //    }
            //}

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Lancamento") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Lancamento").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Lancamento").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

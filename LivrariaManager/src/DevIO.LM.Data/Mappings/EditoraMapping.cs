using DevIO.LM.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.LM.Data.Mappings
{
    public class FornecedorMapping : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {
            builder.HasKey(p => p.Id);
              
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasColumnType("varchar(200)");
           
            // 1 : N => Editora : Livros
            builder.HasMany(f => f.Livros)
                .WithOne(p => p.Editora)
                .HasForeignKey(p => p.EditoraId);

            builder.ToTable("Editoras");
        }
    }
}

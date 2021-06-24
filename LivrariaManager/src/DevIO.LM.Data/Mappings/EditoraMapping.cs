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

            builder.Property(p => p.CodEditora)
                .IsRequired()
                .HasColumnType("varchar(100)"); 

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            // 1 : 1 => Fornecedor : Endereco
            builder.HasOne(f => f.Endereco)
                .WithOne(e => e.Editora);

            // 1 : N => Fornecedor : Produtos
            builder.HasMany(f => f.Livros)
                .WithOne(p => p.Editora)
                .HasForeignKey(p => p.EditoraId);

            builder.ToTable("Editoras");
        }
    }
}

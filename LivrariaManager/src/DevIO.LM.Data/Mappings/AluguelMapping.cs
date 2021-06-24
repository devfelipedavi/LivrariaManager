using DevIO.LM.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.LM.Data.Mappings
{
    public class AluguelMapping : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodAluguel)
                .IsRequired()
                .HasColumnType("varchar(200)");


            // 1 : N => Aluguel : Usuarios
            //builder.HasMany(f => f.Usuarios)
            //    .WithOne(p => p.Aluguel)
            //    .HasForeignKey(p => p.AluguelId);

            // 1 : N => Aluguel : Livros
            //builder.HasMany(f => f.Livros)
            //    .WithOne(p => p.Aluguel)
            //    .HasForeignKey(p => p.AluguelId);

            builder.ToTable("Alugueis");
        }
    }
}

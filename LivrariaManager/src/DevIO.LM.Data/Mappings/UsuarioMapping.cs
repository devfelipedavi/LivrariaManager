using DevIO.LM.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.LM.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CodUsuario)
            .IsRequired()
            .HasColumnType("varchar(200)"); 

            builder.Property(p => p.Nome)
            .IsRequired()
            .HasColumnType("varchar(200)");

            builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("varchar(200)");
            

            // 1 : 1 => Usuario : Endereco
            builder.HasOne(f => f.Endereco)
            .WithOne(e => e.Usuario);

            // 1 : N => Usuario : Alugueis
            builder.HasMany(f => f.Alugueis)
            .WithOne(p => p.Usuario)
            .HasForeignKey(p => p.UsuarioId);

            builder.ToTable("Usuarios");
        }
    }
}

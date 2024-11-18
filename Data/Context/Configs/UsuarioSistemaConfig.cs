using Bussines.Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context.Configs
{
    public class UsuarioSistemaConfig : IEntityTypeConfiguration<UsuarioSistema>
    {
        public void Configure(EntityTypeBuilder<UsuarioSistema> builder)
        {
            builder.HasKey(u => u.UsuarioId);

            builder
                .HasOne(x => x.Usuario)
                .WithMany()
                .HasForeignKey(x => x.UsuarioId);

            builder.Property(u => u.SistemaId)
                .IsRequired();
        }
    }
}

using Bussines.Data.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context.Configs
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.UsuarioId);

            builder.Property(u => u.UsuarioId)
                .ValueGeneratedOnAdd();

            builder.Property(u => u.NomeCompleto)
                .IsRequired();

            builder.Property(u => u.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(u => u.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Senha)
                .IsRequired();

            builder.Property(u => u.TipoPermissao)
                .IsRequired();
        }
    }
}

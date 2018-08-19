using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteApi.Models;

namespace RestauranteApi.Mapeamento
{
    public class RestauranteMap : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("Restaurante");
            builder.HasKey(w => w.Id).HasName("PKRESTAURANTE");
            builder.Property(w => w.Id).HasColumnName("SQRESTAURANTE").ValueGeneratedOnAdd();
            builder.Property(w => w.Descricao).HasColumnName("NMRESTAURANTE").HasMaxLength(255).IsRequired();
        }
    }
}
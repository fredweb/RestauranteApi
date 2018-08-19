using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteApi.Models;

namespace RestauranteApi.Mapeamento
{
    public class PratoMap : IEntityTypeConfiguration<Prato>
    {
        public void Configure(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("PRATO");
            builder.HasKey(w => w.Id).HasName("PKPRATO");
            builder.Property(w => w.Id).HasColumnName("SQPRATO").ValueGeneratedOnAdd();
            builder.Property(w => w.Descricao).HasColumnName("NMPRATO").HasMaxLength(255).IsRequired();
            builder.Property(w => w.RestauranteId).HasColumnName("SQRESTAURANTE").IsRequired();

            builder.HasOne(w => w.Restaurante).WithMany(w => w.Pratos).HasForeignKey(w => w.RestauranteId).HasConstraintName("FKRESTAURANTEPRATO").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
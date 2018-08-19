using Microsoft.EntityFrameworkCore;
using RestauranteApi.Mapeamento;
using RestauranteApi.Models;

namespace RestauranteApi.Contexto
{
    public class RestauranteContexto : DbContext
    {
        public RestauranteContexto(DbContextOptions<RestauranteContexto> options) : base(options)
        {
        }

        public DbSet<Restaurante> Restaurantes { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestauranteMap());
            modelBuilder.ApplyConfiguration(new PratoMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost; user id=root;password=123456;persistsecurityinfo=True;port=3306;database=restaurante;SslMode = none");
            base.OnConfiguring(optionsBuilder);
        }
    }
}

namespace RestauranteApi.Models
{
    public class Prato
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public long RestauranteId { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}

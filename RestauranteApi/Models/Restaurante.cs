using System.Collections.Generic;

namespace RestauranteApi.Models
{
    public class Restaurante
    {
        public long Id { get; set; }

        public string Descricao { get; set; }

        public virtual ICollection<Prato> Pratos { get; set; }
    }
}

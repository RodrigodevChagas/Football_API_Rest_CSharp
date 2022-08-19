using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFutebol.Models
{
    public class Arbitragem
    {
        [Key]
        [Required]
        public int Id { get; set;}

        public string NomeJuiz { get; set; }

        public string NomeBandeira1 { get; set; }

        public string NomeBandeira2 { get; set; }
        [JsonIgnore]
        public virtual List<Confronto> Confrontos { get; set; } 

    }
}

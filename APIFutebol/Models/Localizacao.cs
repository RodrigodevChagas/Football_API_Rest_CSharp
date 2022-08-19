using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFutebol.Models
{
    public class Localizacao
    {
        [Key]
        [Required]

        public int Id { get; set; }
        public string PaisTime1 { get; set; }
        public string PaisTime2 { get; set; }
        public string PaisEvento { get; set; }
        
        [JsonIgnore]
        public virtual List<Confronto> Confrontos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFutebol.Models
{
    public class Resultado
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Placar { get; set; }

        public string Artilharia { get; set; }

        [JsonIgnore]
        public virtual Confronto Confronto { get; set; }

    }
}

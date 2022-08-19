using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIFutebol.Models
{
    public class Confronto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Campeonato { get; set; } = string.Empty;

        [Required]
        public string Times { get; set; } = string.Empty;

        [Required]
        public string Estadio { get; set; } = string.Empty;
        
        public int PublicoPresente { get; set; }
        public int ChutesAGol_Time1{ get; set; }
        public int ChutesAGol_Time2{ get; set; }

        public virtual Resultado Resultado { get; set; }
        [JsonIgnore]
        public int ResultadoId { get; set; }
        public virtual Arbitragem Arbitragem { get; set; }
        [JsonIgnore]
        public int ArbitragemId { get; set; }


        public virtual Localizacao Localizacao { get; set; }
        [JsonIgnore]
        public int LocalizacaoId { get; set; }
    }
}

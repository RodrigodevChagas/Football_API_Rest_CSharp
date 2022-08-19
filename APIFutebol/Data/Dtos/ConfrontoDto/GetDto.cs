using APIFutebol.Models;
using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.ConfrontoDto
{
    public class GetDto
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
        public int ChutesAGol_Time1 { get; set; }
        public int ChutesAGol_Time2 { get; set; }

        public DateTime HoraDaConsulta { get; set; }

        public Resultado Resultado { get; set; }

        public Arbitragem Arbitragem { get; set; }

        public Localizacao Localizacao { get; set; }
    } 
}

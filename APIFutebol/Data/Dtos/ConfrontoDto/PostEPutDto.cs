using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.ConfrontoDto
{
    public class PostEPutDto
    {
        [Required]
        public string Campeonato { get; set; } = string.Empty;

        [Required]
        public string Times { get; set; } = string.Empty;

        [Required]
        public string Estadio { get; set; } = string.Empty;

        public int PublicoPresente { get; set; }
        public int ChutesAGol_Time1 { get; set; }
        public int ChutesAGol_Time2 { get; set; }
        public int ResultadoId { get; set; }
        public int ArbitragemId { get; set; }
        public int LocalizacaoId { get; set; }
    }
}

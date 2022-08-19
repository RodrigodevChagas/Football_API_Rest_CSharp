using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.LocalizacaoDto
{
    public class GetLocalizacaoDto
    {
        [Key]
        [Required]

        public int Id { get; set; }

        public string PaisTimeUm { get; set; }

        public string PaisTimeDois { get; set; }

        public string PaisEvento { get; set; } 
    }
}

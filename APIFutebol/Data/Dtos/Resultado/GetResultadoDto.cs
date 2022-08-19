
using APIFutebol.Models;
using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.ResultadoDto
{
    public class GetResultadoDto
    {
     
        [Key]
        [Required]
        public int Id { get; set; }

        public string Placar { get; set; }

        public string Artilharia { get; set; }
        //public Confronto Confronto { get; set; }
    }
}

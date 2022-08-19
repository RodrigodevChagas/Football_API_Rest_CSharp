using APIFutebol.Models;
using System.ComponentModel.DataAnnotations;

namespace APIFutebol.Data.Dtos.ArbitragemDto
{
    public class GetArbitragemDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string NomeJuiz { get; set; }

        public string NomeBandeira1 { get; set; }

        public string NomeBandeira2 { get; set; }

        public List<Confronto> Confrontos { get; set; }
    }
}

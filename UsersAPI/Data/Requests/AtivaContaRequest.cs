using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string CodigoDeAtivacao { get; set; }
    }
}

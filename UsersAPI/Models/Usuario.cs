using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }


    }
}

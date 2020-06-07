using System.ComponentModel.DataAnnotations;

namespace debt_calculator_api.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string email { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string passwd { get; set; }
    }
}
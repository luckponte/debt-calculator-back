using System.ComponentModel.DataAnnotations;

namespace debt_calculator_api.Models
{
    public class Configs
    {
        [Key]
        public int id {get; set;}
        [Required(ErrorMessage="Campo obrigatório")]
        public int maxParcels { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double interestRate { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double comission { get; set; }
    }
}
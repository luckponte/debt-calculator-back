using System.ComponentModel.DataAnnotations;

namespace debt_calculator_api.Models
{
    public class Debts
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        public long deadlineDate { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double debtValue { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double interestValue { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double finalValue { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string phone {get; set;}

        public Configs Configs { get; set; }
    }
}
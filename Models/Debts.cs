using System.ComponentModel.DataAnnotations;

namespace debt_calculator_api.Models
{
    public class Debts
    {
        [Key]
        public int debtId { get; set; }

        [Required(ErrorMessage="Campo obrigatório")]
        public long deadlineDate { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public double debtValue { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string phone {get; set;}

        public int userId { get; set; }
        public Users User { get; set; }
    }

    public class CalculatedDebts : Debts
    {
        public int maxParcels { get; set; }
        public double interestValue { get; set; }
        public double finalValue { get; set; }
    }
}
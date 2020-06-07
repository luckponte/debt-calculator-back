using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace debt_calculator_api.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string email { get; set; }
        [Required(ErrorMessage="Campo obrigatório")]
        public string passwd { get; set; }
        public bool isAdmin { get; set; }
        public string fullName { get; set; }

        public List<Debts> debts { get; set; }
    }
}
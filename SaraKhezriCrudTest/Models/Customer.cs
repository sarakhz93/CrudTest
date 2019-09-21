using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaraKhezriCrudTest.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must provide a first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must provide a last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must provide a date of birth")]
        public string DateOfBirth { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "You must provide a email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a bank account number")]
        public string BankAccountNumber { get; set; }
    }
}

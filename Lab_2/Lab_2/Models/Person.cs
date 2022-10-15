using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_2.Models
{
    public class Person
    {
        [Required]
        [MaxLength(25)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Special character not allowed.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^([0-9][0-9])-([0-9]+)-([1-3])@student.aiub.edu", ErrorMessage = "You have to use your AIUB email address.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?:(?:\+|00)88|01)?\d{11}$" , ErrorMessage = "Only Bangladeshi number allowed.")]
        public string Phone { get; set; }

        public string DOB { get; set; }
        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
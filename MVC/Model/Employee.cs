using MVC.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Model
{
    [Table("Employee")]
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(64, ErrorMessage = "First name cannot be longer than 64 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(64, ErrorMessage = "Last name cannot be longer than 64 characters.")]
        public string LastName { get; set; }

        public string Avatar { get; set; }

        //[Required(ErrorMessage ="Pesel is required.")]
        //[MinLength(11, ErrorMessage = "PESEL length must be 11 characters.")]
        //[MaxLength(11, ErrorMessage = "PESEL length must be 11 characters.")]
        //public int Pesel { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string eMail { get; set; }
        public EmployeeType Type { get; set; }

        public User User { get; set; }

        public List<Message> Messages { get; set; }
    }
}

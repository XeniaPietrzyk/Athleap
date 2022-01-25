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
         
        [Required(ErrorMessage = "Email is required.")]
        public string eMail { get; set; }
        public EmployeeType Type { get; set; }

        public List<Competition> Competition { get; set; }
        public Club Club { get; set; }

        public User User { get; set; }

        public List<Message> Messages { get; set; }
    }
}

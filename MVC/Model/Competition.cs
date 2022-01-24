using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Model
{
    [Table("Competition")]
    public class Competition
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public DateTime Term { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public List<Athlete> Athletes { get; set; }

    }
}

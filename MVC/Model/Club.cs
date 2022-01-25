using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    [Table("Club")]
    public class Club
    {
        [Column("ClubId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Club name is required")]
        public string Name { get; set; }
        public string Description { get; set; }

        //navigation properties for EFcore
        public Trainer Trainer {get;set;}
        public List<Athlete> Athletes { get; set; }

    }
}

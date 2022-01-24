using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    [Table("Trainer")]
    public class Trainer : Employee
    {
        public List<Athlete> Athletes { get; set; }
        public Club Club { get; set; }
    }
}

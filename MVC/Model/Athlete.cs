using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    [Table("Athlete")]
    public class Athlete : Employee
    {
        public string Area { get; set; }
        public Trainer Trainer { get; set; }
        public List<Competition> Competition { get; set; }
        public List<CompetitionResults> CompetitionResults { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Model
{
    [Table("CompetitionResults")]
    public class CompetitionResults
    {
        public Guid AthleteId { get; set; }
        public Guid CompetitionId { get; set; }
        public double Score { get; set; }
        public int Mark { get; set; }
    }
} 

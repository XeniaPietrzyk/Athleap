using MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Repository.Interface
{
    public interface ICompetitionRepository : IBaseRepository<Competition>
    {
        List<Competition> GetAllByAthleteId(Guid id);
        Competition GetByAthleteId(Guid athleteId, Guid id);
    }
}

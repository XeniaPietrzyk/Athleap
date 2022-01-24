using MVC.Model;
using System;
using System.Collections.Generic;

namespace MVC.Repository
{
    public interface IAthleteRepository : IEmployeeRepository<Athlete>
    {
        IEnumerable<CompetitionResults> GetCompetitionResultsByCompetition(Guid id);
    }
}

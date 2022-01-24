using MVC.Model;
using System;
using System.Collections.Generic;

namespace MVC.Repository
{
    public interface IAthleteRepository : IBaseRepository<Athlete>
    {
        IEnumerable<Athlete> GetByCompetitionId(Guid id);
        IEnumerable<CompetitionResults> GetCompetitionResultsByCompetition(Guid athleteId, Guid competitionId);
        IEnumerable<double> GetScores(Guid athleteId, Guid competitionId);
        IEnumerable<double> GetMarks(Guid athleteId, Guid competitionId);
    }
}

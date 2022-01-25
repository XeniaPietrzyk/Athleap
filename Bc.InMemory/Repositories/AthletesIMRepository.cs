using MVC.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Db.InMemory
{
    public class AthletesIMRepository : IAthleteRepository
    {
        private List<Athlete> athletes;
        public AthletesIMRepository()
        {
            if (athletes == null)
            {
                var walkizkrowami = new List<Competition>();
                walkizkrowami.Add(new Competition { Id = Guid.NewGuid(), Name = "Siła w łapie", Description = "Kto podnisie najwięcej krów w jak najkrótszym czasie.", Term = DateTime.Now });
                athletes = new List<Athlete>()
                {
                    new Athlete{ Id = Guid.NewGuid(), FirstName = "Dariusz", LastName = "Bicepsik", eMail = "darek.bicepsik@athlead.com", Type = MVC.Helpers.EmployeeType.athlete, Area = "strongman", Competition = walkizkrowami},
                    new Athlete{ Id = Guid.NewGuid(), FirstName = "Ewelina", LastName = "Skoczna", eMail = "ewelina.skoczna@athlead.com", Type = MVC.Helpers.EmployeeType.athlete, Area = "tyczkarka"}
                };
            }
        }

        public void Add(Athlete entity)
        {
            if (athletes.Any(x => x.Id.Equals(entity.Id))) return;
            entity.Id = Guid.NewGuid();
            entity.Type = MVC.Helpers.EmployeeType.athlete;
            athletes.Add(entity);
        }

        public void Delete(Guid id)
        {
            athletes?.Remove(FindFirstByCondition(id));
        }

        public Athlete FindFirstByCondition(Guid id)
        {
            return athletes?.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Athlete> GetAll()
        {
            return athletes;
        }

        public IEnumerable<Athlete> GetByCompetitionId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompetitionResults> GetCompetitionResultsByCompetition(Guid athleteId, Guid competitionId)
        {
            var athlete = FindFirstByCondition(athleteId);
            var competitionResults = athlete.CompetitionResults?.FindAll(x => x.CompetitionId == competitionId);
            return competitionResults;
        }

        public IEnumerable<double> GetScores(Guid athleteId, Guid competitionId)
        {
            var competitionResults = GetCompetitionResultsByCompetition(athleteId, competitionId);
            var scores = new List<double>();
            foreach (var item in competitionResults)
            {
                scores.Add(item.Score);
            }

            return scores;
        }

        public IEnumerable<double> GetMarks(Guid athleteId, Guid competitionId)
        {
            var competitionResults = GetCompetitionResultsByCompetition(athleteId, competitionId);
            var marks = new List<double>();
            foreach (var item in competitionResults)
            {
                marks.Add(item.Mark);
            }

            return marks;
        }

        public Athlete Update(Athlete entity)
        {
            var updateEntity = FindFirstByCondition(entity.Id);
            if (updateEntity != null) updateEntity = entity;
            return FindFirstByCondition(updateEntity.Id);
        }

        public IEnumerable<Athlete> GetAllByCompetitionId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

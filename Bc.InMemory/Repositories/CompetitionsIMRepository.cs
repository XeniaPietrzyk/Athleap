using MVC.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Db.InMemory
{
    public class CompetitionsIMRepository : ICompetitionRepository
    {
        private List<Competition> competitions;
        public CompetitionsIMRepository()
        {
            if (competitions == null)
            {
                competitions = new List<Competition>()
                {
                    new Competition{ Id = Guid.NewGuid(), Name = "Jesienne walki z krowami", Description = "Zawody w przenoszeniu krów na czas.", Term = DateTime.Today}
                };
            }
        }

        public void Add(Competition entity)
        {
            if (competitions.Any(x => x.Id.Equals(entity.Id))) return;
            entity.Id = Guid.NewGuid();
            competitions.Add(entity);
        }

        public void Delete(Guid id)
        {
            competitions?.Remove(FindFirstByCondition(id));
        }

        public Competition FindFirstByCondition(Guid id)
        {
            return competitions?.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Competition> GetAll()
        {
            return competitions;
        }

        public IEnumerable<CompetitionResults> GetCompetitionResultsByAthlete(Guid athleteId, Guid competitionId)
        {
            var competition = FindFirstByCondition(competitionId);
            var athlete = competition.Athletes?.FirstOrDefault(x => x.Id == athleteId);
            var competitionResults = athlete.CompetitionResults?.FindAll(x => x.CompetitionId == competitionId);
            return competitionResults;
        }

        public IEnumerable<double> GetScores(Guid athleteId, Guid competitionId)
        {
            var competitionResults = GetCompetitionResultsByAthlete(athleteId, competitionId);
            var scores = new List<double>();
            foreach (var item in competitionResults)
            {
                scores.Add(item.Score);
            }

            return scores;
        }

        public IEnumerable<double> GetMarks(Guid athleteId, Guid competitionId)
        {
            var competitionResults = GetCompetitionResultsByAthlete(athleteId, competitionId);
            var marks = new List<double>();
            foreach (var item in competitionResults)
            {
                marks.Add(item.Mark);
            }

            return marks;
        }

        public Competition Update(Competition entity)
        {
            var updateEntity = FindFirstByCondition(entity.Id);
            if (updateEntity != null) updateEntity = entity;
            return FindFirstByCondition(updateEntity.Id);
        }

        public List<Competition> GetAllByAthleteId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Competition GetByAthleteId(Guid athleteId, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

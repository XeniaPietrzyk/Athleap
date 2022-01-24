using MVC.Model;
using MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Db.InMemory
{
    public class AthletesIMRepository : IAthleteRepository
    {
        private List<Athlete> athletes;
        public AthletesIMRepository()
        {
            //Default trainers
            athletes = new List<Athlete>()
            {
                new Athlete{ Id = Guid.NewGuid(), FirstName = "Dariusz", LastName = "Bicepsik", eMail = "darek.bicepsik@athlead.com", Type = MVC.Helpers.EmployeeType.athlete},
                new Athlete{ Id = Guid.NewGuid(), FirstName = "Ewelina", LastName = "Skoczna", eMail = "ewelina.skoczna@athlead.com", Type = MVC.Helpers.EmployeeType.athlete}

            };
        }

        public void Add(Athlete entity)
        {
            if (athletes.Any(x => x.Id.Equals(entity.Id))) return;            
            entity.Id = Guid.NewGuid();
            entity.Type = MVC.Helpers.EmployeeType.trainer;
            athletes.Add(entity);
        }

        public void Delete(Guid id)
        {
            athletes?.Remove(FindFirstByCondition(id));
        }

        public Athlete FindFirstByCondition(Guid id)
        {
            return athletes?.FirstOrDefault(x=>x.Id==id);
        }

        public IEnumerable<Athlete> GetAll()
        {
            return athletes;
        }

        public IEnumerable<Athlete> GetByCompetitionId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompetitionResults> GetCompetitionResultsByCompetition(Guid id)
        {
            throw new NotImplementedException();
        }

        public Athlete Update(Athlete entity)
        {
            var updateEntity = FindFirstByCondition(entity.Id);
            if (updateEntity != null) updateEntity = entity;
            return FindFirstByCondition(updateEntity.Id);
        }
    }
}

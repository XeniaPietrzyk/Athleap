using MVC.Model;
using MVC.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Db.InMemory
{
    public class TrainersIMRepository : ITrainerRepository
    {
        private List<Trainer> trainers;
        public TrainersIMRepository()
        {
            //Default trainers
            trainers = new List<Trainer>()
            {
                new Trainer{ Id = Guid.NewGuid(), FirstName = "Jan", LastName = "Ciężarek", eMail = "jan.ciezarek@athlead.com", Type = MVC.Helpers.EmployeeType.trainer}
            };
        }

        public void Add(Trainer entity)
        {
            if (trainers.Any(x => x.Id.Equals(entity.Id))) return;
            entity.Id = Guid.NewGuid();
            entity.Type = MVC.Helpers.EmployeeType.trainer;
            trainers.Add(entity);
        }

        public void Delete(Guid id)
        {
            trainers?.Remove(FindFirstByCondition(id));
        }

        public Trainer FindFirstByCondition(Guid id)
        {
            return trainers?.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Trainer> GetAll()
        {
            return trainers;
        }

        public IEnumerable<Trainer> GetByCompetitionId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Trainer Update(Trainer entity)
        {
            var updateEntity = FindFirstByCondition(entity.Id);
            if (updateEntity != null) updateEntity = entity;
            return FindFirstByCondition(updateEntity.Id);
        }
    }
}

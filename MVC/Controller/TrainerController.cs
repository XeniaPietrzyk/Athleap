using Microsoft.AspNetCore.Mvc;
using MVC.Model;
using MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerRepository _trainerRepository;
        public TrainerController(ITrainerRepository trainerConfiguration)
        {
            _trainerRepository = trainerConfiguration;
        }


        [HttpPost]
        public void Create(Trainer trainer)
        {
            try
            {
                _trainerRepository.Add(trainer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //var trainer = _trainerRepository.FindFirstByCondition(id);
                _trainerRepository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IEnumerable<Trainer> GetEmployees() => _trainerRepository.GetAll();

        public Trainer Get(Guid id)
        {
            try
            {
                var trainer = _trainerRepository.FindFirstByCondition(id);
                return trainer;
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut]
        public void Update(Trainer trainer)
        {
            try
            {
               _trainerRepository.Update(trainer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

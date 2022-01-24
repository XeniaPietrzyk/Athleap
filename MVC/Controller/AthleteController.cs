using Microsoft.AspNetCore.Mvc;
using MVC.Model;
using MVC.Repository;
using System;
using System.Collections.Generic;

namespace MVC.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteRepository _athleteRepository;
        public AthleteController(IAthleteRepository athleteConfiguration)
        {            
            _athleteRepository = athleteConfiguration;
        }

        [HttpPost]
        public void Create(Athlete athlete)
        {
            _athleteRepository.Add(athlete);
        }

        [HttpGet]
        public IEnumerable<Athlete> GetAtletes() => _athleteRepository.GetAll();

        public Athlete Get(Guid id)
        {
            try
            {
                var athlete = _athleteRepository.FindFirstByCondition(id);
                return athlete;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IEnumerable<Athlete> GetAthletesByCompetition(Guid id)
        {
            try
            {
                return _athleteRepository.GetByCompetitionId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CompetitionResults> GetCompetitionResultsByCompetition(Guid id)
        {
            try
            {
                return _athleteRepository.GetCompetitionResultsByCompetition(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public void Update(Athlete athlete)
        {
            try
            {
                _athleteRepository.Update(athlete);
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
                //var athlete = _athleteRepository.FindFirstByCondition(id);
                _athleteRepository.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

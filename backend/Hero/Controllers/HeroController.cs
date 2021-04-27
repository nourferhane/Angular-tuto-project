using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using HeroProject.Data;
using HeroProject.Dtos;
using HeroProject.Models;
using Microsoft.AspNetCore.Cors;

namespace HeroProject.Controllers
{
    [Route("api/heros")]
    [ApiController]
    [EnableCors("policy")]
    public class HeroController : ControllerBase
    {
        /// <summary>
        /// the hero repo.
        /// </summary>
        private readonly IHeroRepository _heroRepository;

        /// <summary>
        /// 
        /// </summary>
        private readonly IMapper _mapper;

        public HeroController(IHeroRepository heroRepository, IMapper mapper)
        {
            _heroRepository = heroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HeroDto>> GetAllHeros([FromServices] IHeroRepository heroRepository)
        {
            var heros = _heroRepository.GetHeroes();
            if (!heros.Any())
                return BadRequest("empty data");
            return Ok(_mapper.Map<IEnumerable<HeroDto>>(heros));
        }

        [HttpGet("{id}")]
        public ActionResult<HeroDto> GetHeroById(int id)
        {
            var hero = _heroRepository.GetById(id);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<HeroDto>(hero));
        }

        [HttpPost()]
        public ActionResult CreateHero(Hero hero)
        {
            _heroRepository.CreateHero(hero);

            return Ok(204);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateHero(int id,Hero hero)
        {
            var heroToUpdate = _heroRepository.GetById(id);

            if (heroToUpdate == null)
                return BadRequest();

            _heroRepository.UpdateHero(id,hero);

            return Ok(204);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHero(int id)
        {
            var heroToDelete = _heroRepository.GetById(id);

            if (heroToDelete == null)
                return BadRequest("NOt found");

            _heroRepository.DeleteHero(id);

            return Ok(204);
        }
    }
}

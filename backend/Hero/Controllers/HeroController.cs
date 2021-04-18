using Microsoft.AspNetCore.Mvc;
using HeroProject.Data;
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

        public HeroController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public ActionResult<Models.Hero> GetAllHeros()
        {
            var heros = _heroRepository.GetHeroes();
            return Ok(heros);
        }

        [HttpGet("{id}")]
        public ActionResult<Models.Hero> GetHeroById(int id)
        {
            var hero = _heroRepository.GetById(id);
            if (hero == null)
                return BadRequest();

            return Ok(hero);
        }


    }
}

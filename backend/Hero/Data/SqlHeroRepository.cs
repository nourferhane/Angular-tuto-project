using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeroProject.Models;

namespace HeroProject.Data
{
    public class SqlHeroRepository : IHeroRepository
    {
        private readonly HeroContext _heroContext;

        public SqlHeroRepository(HeroContext heroContext)
        {
            _heroContext = heroContext;
        }

        /// <summary>
        /// Get All Heros
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Hero> GetHeroes()
        {
            return _heroContext.Heroes.ToList();
        }

        /// <summary>
        /// Get hero by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hero GetById(int id)
        {
            return _heroContext.Heroes.FirstOrDefault(h => h.Id == id);
        }

        /// <summary>
        /// Create a new Hero
        /// </summary>
        /// <param name="hero"></param>
        public void CreateHero(Hero hero)
        {
            _heroContext.Add(hero);
            _heroContext.SaveChanges();
        }

        public void UpdateHero(int id, Hero hero)
        {
            throw new NotImplementedException();
        }

        public Hero FindByName(string name)
        {
            return _heroContext.Heroes.FirstOrDefault(h => string.Equals(h.Name,name,StringComparison.InvariantCultureIgnoreCase));
        }

        public void DeleteHero(int id)
        {
            throw new NotImplementedException();
        }
    }
}

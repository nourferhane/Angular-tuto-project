using System.Collections.Generic;
using HeroProject.Models;

namespace HeroProject.Data
{
    /// <summary>
    /// The hero repo interface.
    /// </summary>
    public interface IHeroRepository
    {
        IEnumerable<Models.Hero> GetHeroes();

        Models.Hero GetById(int id);

        void CreateHero(Hero hero);

    }
}

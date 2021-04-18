using System.Collections.Generic;

namespace HeroProject.Data
{
    /// <summary>
    /// The hero repo interface.
    /// </summary>
    public interface IHeroRepository
    {
        IEnumerable<Models.Hero> GetHeroes();

        Models.Hero GetById(int Id);

    }
}

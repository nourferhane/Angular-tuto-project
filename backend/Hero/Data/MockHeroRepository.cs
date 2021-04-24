using System;
using System.Collections.Generic;
using System.Linq;
using Hero = HeroProject.Models.Hero;

namespace HeroProject.Data
{
    public class MockHeroRepository : IHeroRepository
    {
        List<Models.Hero> heroList = new List<Models.Hero>()
        {
            new Models.Hero()
            {
                Id = 0,
                Name  ="hero0"
            },
            new Models.Hero()
            {
                Id = 1,
                Name  ="hero1"
            },
            new Models.Hero()
            {
                Id = 2,
                Name  ="hero2"
            },
            new Models.Hero()
            {
                Id = 3,
                Name  ="hero3"
            },
            new Models.Hero()
            {
                Id = 4,
                Name  ="hero4"
            },
            new Models.Hero()
            {
                Id = 5,
                Name  ="hero5"
            },
        };

        public IEnumerable<Models.Hero> GetHeroes()
        {
            return heroList;
        }

        public Models.Hero GetById(int id)
        {
            return heroList.Find(h => h.Id == id);
        }

        public void CreateHero(Hero hero)
        {
            hero.Id = heroList.Last().Id + 1;
            heroList.Add(hero);
        }

        public void UpdateHero(int id, Hero hero)
        {
            var heroToUpdate = heroList.Find(h => h.Id == id);
            heroToUpdate.Name = hero.Name;
            heroList[heroToUpdate.Id] = heroToUpdate;
        }

        public Hero FindByName(string name)
        {
            return heroList.Find(h => h.Name == name);
        }

        public void DeleteHero(int id)
        {
            heroList.RemoveAll(h => h.Id == id);
        }
    }
}

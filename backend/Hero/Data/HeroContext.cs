using HeroProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroProject.Data
{
    /// <summary>
    /// The hero context class.
    /// </summary>
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> opt) : base(opt)
        {
                
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}

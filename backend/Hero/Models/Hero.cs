using System.ComponentModel.DataAnnotations;

namespace HeroProject.Models
{
    /// <summary>
    /// The Hero Class.
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// The Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The name of the hero.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}

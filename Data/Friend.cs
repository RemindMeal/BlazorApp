using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealBlazorApp.Data
{
    public sealed class Friend
    {
        public Friend()
        {
            Presences = new List<Presence>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Prénom")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Nom")]
        public string Surname { get; set; }
        
        [Display(Name = "Nom")]
        public string FullName => $"{Name} {Surname}";

        // Relationships
        public ICollection<Presence> Presences { get; set; }

        public override string ToString()
        {
            return FullName;
        }

    }
}
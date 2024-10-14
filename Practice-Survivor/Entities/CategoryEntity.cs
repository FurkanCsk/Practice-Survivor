using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Practice_Survivor.Entities
{
    public class CategoryEntity : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public ICollection<CompetitorEntity>? Competitors { get; set; }
    }
}

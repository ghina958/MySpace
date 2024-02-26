using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpace.DomainModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        public Space? Space { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MySpace.DomainModel
{
    public class Space
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }

        public ICollection<Member> Members { get; set; }
    }
}

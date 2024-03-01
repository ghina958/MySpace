using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MySpace.DomainModel
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Member")] //refernce who created
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        public ICollection<Files> Files { get; set; }

    }
}

using MySpace.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpace.DomainModel
{
    public class Member
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        public Space? Space { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public int RoleId { get; set; }
        public Roles Role { get => (Roles)RoleId; set => RoleId = (int)Role; }
        public ICollection<Note> Notes { get; set; }
    }
}

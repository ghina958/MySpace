using Domain.Abstract;
using Domain.enums;

namespace Domain
{
    public class Member : BaseEntity<int>
    {
        public int SpaceId { get; set; }
        public Space Space { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public Role Role { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}

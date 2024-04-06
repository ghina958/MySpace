using Domain.Abstract;

namespace Domain
{
    public class Space : BaseEntity<int>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Member> Members { get; set; }

    }
}

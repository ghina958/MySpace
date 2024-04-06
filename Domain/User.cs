using Domain.Abstract;

namespace Domain
{
    public class User : BaseEntity<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<Member> Memberships { get; set; }
    }
}

using Domain.Abstract;

namespace Domain
{
    public class Note : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Color { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CreatorId { get; set; }
        public Member Creator { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

    }
}

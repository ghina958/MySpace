using Domain.Abstract;

namespace Domain
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }
        public int SpaceId { get; set; }
        public Space Space { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}

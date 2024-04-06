using Domain.Abstract;

namespace Domain
{
    public class File : BaseEntity<int>
    {
        public string Url { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace MySpace.DomainModel
{
    public class File
    {
        public int Id { get; set; }
       // [StringLength(maximumLength:)]
        public string Url { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}

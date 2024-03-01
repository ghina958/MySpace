using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySpace.DomainModel
{
    public class Files
    {
        [Key]
        public int Id { get; set; }

        [MaxLength]
        public string Url { get; set; }

        [ForeignKey("Note")]
        public int NoteId { get; set; }
        public Note? Note { get; set; }
    }
}

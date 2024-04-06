using Domain.Abstract;

namespace Domain;

public class Attachment : BaseEntity<int>
{
    public int FileId { get; set; }
    public int NoteId { get; set; }
    public File File { get; set; }
    public Note Note { get; set; }
}

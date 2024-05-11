using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Note;
public partial class DeleteNoteRequest : IRequest<DeleteNote>
{
    public class Handler : IRequestHandler<DeleteNoteRequest, DeleteNote>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteNote> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
        {
           
             var ReqNote = await _dbContext.Notes.FindAsync(request.Id, cancellationToken)??
             throw new Exception("Note not found");

             _dbContext.Notes.Remove(ReqNote);
             await _dbContext.SaveChangesAsync(cancellationToken);
             return new DeleteNote
             {
                    Success = true,
                    Message = "Note deleted successfully"
             };
            
        }
    }
}
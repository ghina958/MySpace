using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;

public partial class NoteDataRequest : IRequest<NoteData>
{
    public class Handler : IRequestHandler<NoteDataRequest, NoteData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NoteData> Handle(NoteDataRequest request, CancellationToken cancellationToken)
        {           
                var note = await _dbContext.Notes.Include(c => c.Category).Include(c => c.Creator).FirstOrDefaultAsync(c => c.Id == request.Id)??
                throw new Exception("Note not found");
             
               return _mapper.Map<NoteData>(note);
   
        }
    }



}

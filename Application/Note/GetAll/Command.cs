using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;
public partial class ListNotesRequest : IRequest<ListNotes>
{
    public class Handler : IRequestHandler<ListNotesRequest, ListNotes>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListNotes> Handle(ListNotesRequest request, CancellationToken cancellationToken)
        {
            var notes = await _dbContext.Notes.
                Include(c => c.Category).
                Include(e => e.Creator).ToListAsync();
           return new ListNotes()
            {
                Note = { _mapper.Map<List<NoteData>>(notes) }

            };

        }
    }

}



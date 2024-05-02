using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;
public partial class GetAllNotesRequest : IRequest<GetAllNotesResponse>
{
    public class Handler : IRequestHandler<GetAllNotesRequest, GetAllNotesResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetAllNotesResponse> Handle(GetAllNotesRequest request, CancellationToken cancellationToken)
        {

            var notes = await _dbContext.Notes.
                Include(c => c.Category).
                Include(e => e.Creator).ToListAsync();
           return new GetAllNotesResponse()
            {
                Note = { _mapper.Map<List<GetNoteByIdResponse>>(notes) }

            };

            //return await Task.FromResult(response);

        }
    }

}



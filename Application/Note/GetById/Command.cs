using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;

public partial class GetNoteByIdRequest : IRequest<GetNoteByIdResponse>
{
    public class Handler : IRequestHandler<GetNoteByIdRequest, GetNoteByIdResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetNoteByIdResponse> Handle(GetNoteByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var note = await _dbContext.Notes.Include(c => c.Creator).Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == request.Id)??
               
                    throw new Exception("Note not found");
             
               return _mapper.Map<GetNoteByIdResponse>(note);

                
               
            }catch (Exception ex)
            {
                throw ;

            }
        }
    }



}

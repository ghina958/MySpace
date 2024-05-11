using AutoMapper;
using DataAccess;
using Domain;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;
public partial class NewNoteReq : IRequest<NewNoteData>
{
    public class Handler : IRequestHandler<NewNoteReq, NewNoteData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewNoteData> Handle(NewNoteReq request, CancellationToken cancellationToken)
        {
            var category =await _dbContext.Categories.FirstOrDefaultAsync(c=>c.Id == request.CategoryId)??
            throw new RpcException(new Status(StatusCode.NotFound, "Category not found."));
          
            var creator=await _dbContext.Members.FirstOrDefaultAsync(c=>c.Id==request.CreatorId) ??

                throw new RpcException(new Status(StatusCode.NotFound, "Creator not found."));
            
            var note = _mapper.Map<Domain.Note>(request);
               
                await _dbContext.Notes.AddAsync(note, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
              
                return _mapper.Map<NewNoteData>(note);
            
        }
    }

}


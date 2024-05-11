using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;

public partial class EditNote : IRequest<NewNoteData>
{
    public class Handler : IRequestHandler<EditNote, NewNoteData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewNoteData> Handle(EditNote request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == request.CategoryId) ??
            throw new RpcException(new Status(StatusCode.NotFound, "Category not found."));

            var creator = await _dbContext.Members.FirstOrDefaultAsync(c => c.Id == request.CreatorId) ??
             throw new RpcException(new Status(StatusCode.NotFound, "Creator not found."));

            var NoteReq = await _dbContext.Notes.FirstOrDefaultAsync(s => s.Id == request.Id) ??
              throw new RpcException(new Status(StatusCode.Cancelled, "Edit Note Failed!"));

                _mapper.Map(request, NoteReq);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<NewNoteData>(NoteReq);

           
        }

    }
}
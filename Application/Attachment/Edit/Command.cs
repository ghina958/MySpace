using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace MySpace.Application.Attachment;

public partial class EditAttachmentRequest : IRequest<NewAttachmentData>
{
    public class Handler : IRequestHandler<EditAttachmentRequest, NewAttachmentData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<NewAttachmentData> Handle(EditAttachmentRequest request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.Files.FirstOrDefaultAsync(c => c.Id == request.FileId) ??
           throw new RpcException(new Status(StatusCode.NotFound, "File not found."));

            var Note = await _dbContext.Notes.FirstOrDefaultAsync(c => c.Id == request.NoteId) ??
            throw new RpcException(new Status(StatusCode.NotFound, "Note not found."));

            var attachReq = await _dbContext.Attachments.FirstOrDefaultAsync(s => s.Id == request.Id) ??
              throw new RpcException(new Status(StatusCode.Cancelled, "Edit Attachment Failed!"));

            _mapper.Map(request, attachReq);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<NewAttachmentData>(attachReq);


        }

    }
}
using AutoMapper;
using DataAccess;
using MediatR;
using MySpace.Application.Attachment;

namespace MySpace.Application.Attachment;
public partial class DeleteAttachmentRequest : IRequest<DeleteAttachmentData>
{
    public class Handler : IRequestHandler<DeleteAttachmentRequest, DeleteAttachmentData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeleteAttachmentData> Handle(DeleteAttachmentRequest request, CancellationToken cancellationToken)
        {
            var ReqAttach = await _dbContext.Attachments.FindAsync(request.Id, cancellationToken) ??
            throw new Exception("Note not found");

            _dbContext.Attachments.Remove(ReqAttach);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteAttachmentData
            {
                Success = true,
                Message = "Attachment deleted successfully"
            };

        }
    }
}
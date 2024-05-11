using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Attachment;
public partial class ListAttachmentsRequest : IRequest<ListAttachments>
{
    public class Handler : IRequestHandler<ListAttachmentsRequest, ListAttachments>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListAttachments> Handle(ListAttachmentsRequest request, CancellationToken cancellationToken)
        {
            var attachmenta = await _dbContext.Attachments.
                Include(c => c.Note).
                Include(e => e.File).ToListAsync();
            return new ListAttachments()
            {
                Attachment = { _mapper.Map<List<AttachmentData>>(attachmenta) }

            };

        }
    }

}

using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Attachment;

public partial class AttachDataRequest : IRequest<AttachmentData>
{
    public class Handler : IRequestHandler<AttachDataRequest, AttachmentData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AttachmentData> Handle(AttachDataRequest request, CancellationToken cancellationToken)
        {
            var attach = await _dbContext.Attachments.Include(c => c.Note).Include(c => c.File).FirstOrDefaultAsync(c => c.Id == request.Id) ??
            throw new Exception("Attachment not found");

            return _mapper.Map<AttachmentData>(attach);

        }
    }



}
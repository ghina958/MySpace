﻿using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySpace.Application.Note;

namespace MySpace.Application.Attachment;
public partial class NewAttachment : IRequest<NewAttachmentData>
{
    public class Handler : IRequestHandler<NewAttachment, NewAttachmentData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NewAttachmentData> Handle(NewAttachment request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.Files.FirstOrDefaultAsync(c => c.Id == request.FileId) ??
            throw new RpcException(new Status(StatusCode.NotFound, "File not found."));

            var Note = await _dbContext.Notes.FirstOrDefaultAsync(c => c.Id == request.NoteId) ??
            throw new RpcException(new Status(StatusCode.NotFound, "Note not found."));

            var attach = _mapper.Map<Domain.Attachment>(request);

            await _dbContext.Attachments.AddAsync(attach, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<NewAttachmentData>(attach);

        }
    }

}

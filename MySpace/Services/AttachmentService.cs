using Grpc.Core;
using MediatR;
using MySpace.Application.Attachment;

namespace MySpace.WebAPI.Services;
internal class AttachmentService : Attachments.AttachmentsBase
{
    private readonly IMediator _mediator;

    public AttachmentService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<NewAttachmentData> Create(NewAttachment request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<NewAttachmentData> Edit(EditAttachmentRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<DeleteAttachmentData> Delete(DeleteAttachmentRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<AttachmentData> GetById(AttachDataRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<ListAttachments> List(ListAttachmentsRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
}
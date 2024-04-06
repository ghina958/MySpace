using Grpc.Core;
using MediatR;
using MySpace.Application.Note;

namespace MySpace.WebAPI.Services;

internal class NoteService : Notes.NotesBase
{
    private readonly IMediator _mediator;
    public NoteService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override Task<CreateNoteResponse> CreateNote(CreateNoteRequest request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }

    public override Task<GetNoteByIdResponse> GetNoteById(GetNoteByIdRequest request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }


}

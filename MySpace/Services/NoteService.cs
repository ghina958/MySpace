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

    public override Task<NewNoteData> Create(NewNoteReq request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }
    public override Task<NewNoteData> Edit(EditNote request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }
    public override Task<DeleteNote> Delete(DeleteNoteRequest request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }

    public override Task<NoteData> ById(NoteDataRequest request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }
    public override Task<ListNotes> List(ListNotesRequest request, ServerCallContext context)
    {
        return _mediator.Send(request);
    }


}

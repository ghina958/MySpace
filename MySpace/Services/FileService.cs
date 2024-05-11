using Grpc.Core;
using MediatR;
using MySpace.Application.Files;

namespace MySpace.WebAPI.Services;
internal class FileService : Files.FilesBase
{
    private readonly IMediator _mediator;

    public FileService(IMediator mediator)
    {
        _mediator = mediator;
    }
    //public override Task<FileResponse> CreateFile(CreatFile request, ServerCallContext context)
    //{
    //    return  _mediator.Send(request);
    //}
    //public override async Task<FileResponse> GetByIdFile(FileById request, ServerCallContext context)
    //{
    //    return await _mediator.Send(request);
    //}
}

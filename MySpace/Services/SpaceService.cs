using Grpc.Core;
using MediatR;
using MySpace.Application.Space;

namespace MySpace.WebAPI.Services;
internal class SpaceService : Spaces.SpacesBase
{
    private readonly IMediator _mediator;

    public SpaceService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<CreateSpaceResponse> CreateSpace(CreateSpaceRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<EditSpaceResponse> EditSpace(EditSpaceRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<DeleteSpaceResponse> DeleteSpace(DeleteSpaceRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<GetSpaceByIdResponse> GetSpaceById(GetSpaceByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<GetAllSpacesResponse> GetAllSpaces(GetAllSpacesRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }



}
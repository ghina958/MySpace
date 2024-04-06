using Grpc.Core;
using MediatR;
using MySpace.Application.Member;

namespace MySpace.WebAPI.Services;
internal class MembersService : Members.MembersBase
{
    private readonly IMediator _mediator;

    public MembersService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<CreateMemberResponse> CreateMember(CreateMemberRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetAllMembersResponse> GetAllMembers(GetAllMembersRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetMemberByIdResponse> GetByIdMember(GetMemberByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
}
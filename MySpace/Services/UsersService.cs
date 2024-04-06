using Grpc.Core;
using MediatR;
using MySpace.Application.User;

namespace MySpace.WebAPI.Services;
internal class UsersService : Users.UsersBase
{
    private readonly IMediator _mediator;

    public UsersService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<CreateUserResponse> CreateUser(CreateUserRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<EditUserResponse> EditUser(EditUserRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<DeleteUserResponse> DeleteUser(DeleteUserRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetAllUsersResponse> ListUsers(GetAllUsersRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);

    }

}

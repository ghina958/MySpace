using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.User;

public partial class DeleteUserRequest : IRequest<DeleteUserResponse>
{
    public class Handler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var reqUser = await _dbContext.Users.FindAsync(request.Id, cancellationToken);
                if (reqUser == null)
                {
                    throw new Exception("User not found");
                }
                _dbContext.Users.Remove(reqUser);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new DeleteUserResponse
                { Success = true, Message = "User deleted successfully" };
            }
            catch (Exception ex)
            {
                return new DeleteUserResponse
                {
                    Success = false,
                    Message = ex.Message
                };
            }

        }
    }
}

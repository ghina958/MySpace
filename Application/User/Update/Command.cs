using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.User;

public partial class EditUserRequest : IRequest<EditUserResponse>
{
    public class Handler : IRequestHandler<EditUserRequest, EditUserResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EditUserResponse> Handle(EditUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var requstUser = _mapper.Map<Domain.User>(request);
                if(requstUser != null)
                {
                    _dbContext.Entry(requstUser).State = EntityState.Modified;
                   // await _dbContext.Users.Update(requstUser, cancellationToken);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<EditUserResponse>(requstUser);
                    // throw new Exception("User not found.");
                }
                throw new RpcException(new Status(StatusCode.Cancelled, "Edit Order Failed!"));
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

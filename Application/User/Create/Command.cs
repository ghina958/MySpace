using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.User;
public partial class CreateUserRequest : IRequest<CreateUserResponse>
{
    public class Handler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<Domain.User>(request);
                await _dbContext.Users.AddAsync(user, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CreateUserResponse>(user);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

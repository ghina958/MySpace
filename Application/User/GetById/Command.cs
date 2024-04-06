using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.User;

public partial class GetUserByIdRequest : IRequest<GetUserByIdResponse>
{
    public class Handler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(request.Id, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var getUserByIdRespo = _mapper.Map<GetUserByIdResponse>(user);
            return getUserByIdRespo;

        }
    }
}

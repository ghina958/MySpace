using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Member;
public partial class CreateMemberRequest : IRequest<CreateMemberResponse>
{
    public class Handler : IRequestHandler<CreateMemberRequest, CreateMemberResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateMemberResponse> Handle(CreateMemberRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.UserId);
                if (user == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "User not found."));
                }
                var space = await _dbContext.Spaces.FirstOrDefaultAsync(c => c.Id == request.SpaceId);
                if (space == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Space not found."));

                }
                var member = _mapper.Map<Domain.Member>(request);

                await _dbContext.Members.AddAsync(member, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CreateMemberResponse>(member);

            }catch (Exception ex)
            {
                throw;
            }
            

        }
    }

}


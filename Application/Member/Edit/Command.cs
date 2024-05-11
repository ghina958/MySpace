using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Member;
public partial class EditMember : IRequest<CreateMemberResponse>
{
    public class Handler : IRequestHandler<EditMember, CreateMemberResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateMemberResponse> Handle(EditMember request, CancellationToken cancellationToken)
        {
        
            var user = await _dbContext.Users.FirstOrDefaultAsync(c => c.Id == request.UserId)??             
                  throw new RpcException(new Status(StatusCode.NotFound, "User not found."));
                
            var space = await _dbContext.Spaces.FirstOrDefaultAsync(c => c.Id == request.SpaceId)??
                  throw new RpcException(new Status(StatusCode.NotFound, "Space not found."));

            var memberReq= await _dbContext.Members.FirstOrDefaultAsync(s => s.Id == request.Id) ??
              throw new RpcException(new Status(StatusCode.Cancelled, "Edit Member Failed!"));

                 _mapper.Map(request, memberReq);
                 await _dbContext.SaveChangesAsync(cancellationToken);
                 return _mapper.Map<CreateMemberResponse>(memberReq);

        }
    }

}


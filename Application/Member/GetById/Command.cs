using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Member;
public partial class GetMemberByIdRequest : IRequest<GetMemberByIdResponse>
{
    public class Handler : IRequestHandler<GetMemberByIdRequest, GetMemberByIdResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetMemberByIdResponse> Handle(GetMemberByIdRequest request, CancellationToken cancellationToken)
        {
            var member = await _dbContext.Members
                .Include(x => x.Space)
                .Include(x => x.User)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??
                throw new Exception("member not found");

            return _mapper.Map<GetMemberByIdResponse>(member);

        }
    }

}


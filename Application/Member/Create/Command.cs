using AutoMapper;
using DataAccess;
using MediatR;

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
            var member = _mapper.Map<Domain.Member>(request);

            await _dbContext.Members.AddAsync(member, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<CreateMemberResponse>(member);

        }
    }

}


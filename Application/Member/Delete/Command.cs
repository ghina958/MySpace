using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Member;
public partial class DeleteMemberRequest : IRequest<DeleteMember>
{
    public class Handler : IRequestHandler<DeleteMemberRequest, DeleteMember>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteMember> Handle(DeleteMemberRequest request, CancellationToken cancellationToken)
        {

            var ReqMember = await _dbContext.Members.FindAsync(request.Id, cancellationToken) ??
            throw new Exception("Member not found");

            _dbContext.Members.Remove(ReqMember);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteMember
            {
                Success = true,
                Message = "Member deleted successfully"
            };

        }
    }
}
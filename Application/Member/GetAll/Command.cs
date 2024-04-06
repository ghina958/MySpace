using AutoMapper;
using DataAccess;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySpace.Application.Category;

namespace MySpace.Application.Member;
public partial class GetAllMembersRequest : IRequest<GetAllMembersResponse>
{
    public class Handler : IRequestHandler<GetAllMembersRequest, GetAllMembersResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetAllMembersResponse> Handle(GetAllMembersRequest request, CancellationToken cancellationToken)
        {
            var response = new GetAllMembersResponse();
            var member = await _dbContext.Members.Include(c => c.Space).Include(c => c.User).ToListAsync();
            foreach (var item in member)
            {
                var mapp = _mapper.Map<GetMemberByIdResponse>(item);
                response.Member.Add(mapp);
            }
            return await Task.FromResult(response);

        }
    }

}


using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;

public partial class GetByIdRequest : IRequest<GetByIdResponse>
{
    public class Handler : IRequestHandler<GetByIdRequest, GetByIdResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
        {
            var category = await _dbContext.Categories.Include(c => c.Space).FirstOrDefaultAsync(c => c.Id ==request.Id, cancellationToken);
            if (category == null)
            {

                throw new Exception("Category not found");
            }
            
            var getCategoryRepo = _mapper.Map<GetByIdResponse>(category);
            return getCategoryRepo;
        }
    }


}
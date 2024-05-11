using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;

public partial class CategoryDataRequest : IRequest<OneCategoryData>
{
    public class Handler : IRequestHandler<CategoryDataRequest, OneCategoryData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<OneCategoryData> Handle(CategoryDataRequest request, CancellationToken cancellationToken)
        {

            var category = await _dbContext.Categories.Include(c => c.Space).FirstOrDefaultAsync(c => c.Id ==request.Id, cancellationToken);
            if (category == null)
            {

                throw new Exception("Category not found");
            }
            
            var getCategoryRepo = _mapper.Map<OneCategoryData>(category);
            return getCategoryRepo;
        }
    }


}
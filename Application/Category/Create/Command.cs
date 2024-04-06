using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;
public partial class CreateCategoryrRequest : IRequest<CreateCategoryResponse>
{
    public class Handler : IRequestHandler<CreateCategoryrRequest, CreateCategoryResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateCategoryResponse> Handle(CreateCategoryrRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var category = _mapper.Map<Domain.Category>(request);
                await _dbContext.Categories.AddAsync(category, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CreateCategoryResponse>(category);

            }
            catch (Exception ex)
            {
                throw;

            }


        }


    }
}

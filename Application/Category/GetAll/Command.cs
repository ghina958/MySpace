using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;

public partial class ListCategoriesRequest : IRequest<ListCategories>
{
    public class Handler : IRequestHandler<ListCategoriesRequest, ListCategories>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ListCategories> Handle(ListCategoriesRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var response = new ListCategories();
                var category = await _dbContext.Categories.Include(c => c.Space).ToListAsync();
               
                    foreach (var item in category)
                    {
                        var mapp = _mapper.Map<OneCategoryData>(item);
                        response.Category.Add(mapp);
                    }
                    return await Task.FromResult(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

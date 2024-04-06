using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;

public partial class GetAllCategoriesRequest : IRequest<GetAllCategoriesResponse>
{
    public class Handler : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var response = new GetAllCategoriesResponse();
                var category = await _dbContext.Categories.Include(c => c.Space).ToListAsync();
               
                    foreach (var item in category)
                    {
                        var mapp = _mapper.Map<GetByIdResponse>(item);
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

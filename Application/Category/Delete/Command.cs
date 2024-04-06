using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Category;
public partial class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
{
    public class Handler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ReqCategory = await _dbContext.Categories.FindAsync(request.Id, cancellationToken);
                if(ReqCategory == null)
                {

                    throw new Exception("Category not found");
                }
                _dbContext.Categories.Remove(ReqCategory);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new DeleteCategoryResponse
                {
                    Success = true,
                    Message = "User deleted successfully"
                };


            }
            catch (Exception ex) 
            {

                return new DeleteCategoryResponse
                {
                    Success = false,
                    Message = "User deleted failed"
                };

            }
        }
    }
}
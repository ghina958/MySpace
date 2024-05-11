using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Category;

public partial class EditCategory : IRequest<CategoryData>
{
    public class Handler : IRequestHandler<EditCategory, CategoryData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CategoryData> Handle(EditCategory request, CancellationToken cancellationToken)
        {
            try
            {
                var space = await _dbContext.Spaces.FirstOrDefaultAsync(m => m.Id == request.SpaceId);
                if (space == null)
                {
                    throw new RpcException(new Status(StatusCode.NotFound, "Space not found."));

                }
                var exitingCategory = await _dbContext.Categories.FirstOrDefaultAsync(s => s.Id == request.Id);
                if (exitingCategory == null)
                {
                    throw new RpcException(new Status(StatusCode.Cancelled, "Edit Order Failed!"));

                }
                else
                {
                    _mapper.Map(request, exitingCategory);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<CategoryData>(exitingCategory);

                }
            }
            catch (Exception ex)
            {

                throw new RpcException(new Status(StatusCode.Internal, $"Failed to edit category: {ex.Message}"));

            }
        }
    }

}
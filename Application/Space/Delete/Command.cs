using AutoMapper;
using DataAccess;
using MediatR;


namespace MySpace.Application.Space;
public partial class DeleteSpaceRequest : IRequest<DeleteSpaceResponse>
{
    public class Handler : IRequestHandler<DeleteSpaceRequest, DeleteSpaceResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<DeleteSpaceResponse> Handle(DeleteSpaceRequest request, CancellationToken cancellationToken)
        {
            var space = await _dbContext.Spaces.FindAsync(request.Id, cancellationToken);
            if (space != null)
            {
                _dbContext.Spaces.Remove(space);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return new DeleteSpaceResponse {
                    Success = true,
                    Message = "Space deleted successfully"
                };
                    
                
            }
            else
            {
                return new DeleteSpaceResponse
                {
                    Success = false,
                    Message = "Space deleted failed"
                };


            }


        }
    }


}
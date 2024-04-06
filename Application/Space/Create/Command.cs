using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Space;

public partial class CreateSpaceRequest : IRequest<CreateSpaceResponse>
{
    public class Handler : IRequestHandler<CreateSpaceRequest, CreateSpaceResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateSpaceResponse> Handle(CreateSpaceRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var space =_mapper.Map<Domain.Space>(request);
               await _dbContext.Spaces.AddAsync(space, cancellationToken);
               await _dbContext.SaveChangesAsync(cancellationToken);
               return _mapper.Map<CreateSpaceResponse>(space);
            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }


}

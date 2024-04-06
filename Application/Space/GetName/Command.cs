using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Space;

public partial class GetSpaceNameRequest : IRequest<GetSpaceNameResponse>
{
    public class Handler : IRequestHandler<GetSpaceNameRequest, GetSpaceNameResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetSpaceNameResponse> Handle(GetSpaceNameRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var space = await _dbContext.Spaces.FindAsync(request.Id, cancellationToken);
                if (space == null)
                {

                    throw new Exception("Space not found");
                }
                var getSpaceRespo = _mapper.Map<GetSpaceNameResponse>(space);
                return getSpaceRespo;


            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }


}

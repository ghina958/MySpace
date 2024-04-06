using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Space;

public partial class GetAllSpacesRequest : IRequest<GetAllSpacesResponse>
{
    public class Handler : IRequestHandler<GetAllSpacesRequest, GetAllSpacesResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetAllSpacesResponse> Handle(GetAllSpacesRequest request, CancellationToken cancellationToken)
        {
            try
            {
               var response =new GetAllSpacesResponse();
                var space =await _dbContext.Spaces.ToListAsync();
                foreach(var item in space)
                {
                    var mapp=_mapper.Map<GetSpaceByIdResponse>(item);
                    response.Space.Add(mapp);

                }
                return await Task.FromResult(response);

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }


}


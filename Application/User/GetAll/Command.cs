using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.User;

    public partial class GetAllUsersRequest : IRequest<GetAllUsersResponse>
    {
        public class Handler : IRequestHandler<GetAllUsersRequest, GetAllUsersResponse>
        {
            private readonly ApplicationDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(ApplicationDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<GetAllUsersResponse> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
            {
                var response = new GetAllUsersResponse();

                var list = await _dbContext.Users.ToListAsync();
               
                 foreach (var item in list)
                 {
                    var mapModel =_mapper.Map<GetUserByIdResponse>(item);
                    response.User.Add(mapModel);
                 }
                return await Task.FromResult(response);
            }
        }
    }

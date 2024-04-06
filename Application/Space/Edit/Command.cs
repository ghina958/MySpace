using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MySpace.Application.Space;
public partial class EditSpaceRequest : IRequest<EditSpaceResponse>
{
    public class Handler : IRequestHandler<EditSpaceRequest, EditSpaceResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<EditSpaceResponse> Handle(EditSpaceRequest request, CancellationToken cancellationToken)
        {

            var existingSpace = await _dbContext.Spaces.FirstOrDefaultAsync(s => s.Id == request.Id);

            if (existingSpace == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Space not found."));
            }
            try
            {
                //Apply the changes from the request to the existing space entity
                _mapper.Map(request, existingSpace);
               // Save changes to the database
               await _dbContext.SaveChangesAsync(cancellationToken);
              //  Map the updated space to response and return
                return _mapper.Map<EditSpaceResponse>(existingSpace);
            }
            catch (Exception ex)
            {
               // Handle any exceptions that occur during the edit process
                throw new RpcException(new Status(StatusCode.Internal, $"Failed to edit space: {ex.Message}"));
            }
        }
    }


}
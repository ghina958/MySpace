using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Files;
public partial class DeleteFileDataRequest : IRequest<DeleteFileData>
{
    public class Handler : IRequestHandler<DeleteFileDataRequest, DeleteFileData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeleteFileData> Handle(DeleteFileDataRequest request, CancellationToken cancellationToken)
        {

            var ReqFile = await _dbContext.Files.FindAsync(request.Id, cancellationToken) ??
            throw new Exception("File not found");

            _dbContext.Files.Remove(ReqFile);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new DeleteFileData
            {
                Success = true,
                Message = "Note deleted successfully"
            };

        }
    }
}
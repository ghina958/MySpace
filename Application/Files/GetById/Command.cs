using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Files;
public partial class FileById : IRequest<FileResponse>
{
    public class Handler : IRequestHandler<FileById, FileResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<FileResponse> Handle(FileById request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.Files.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??
                throw new Exception("file not found");

            return _mapper.Map<FileResponse>(file);

        }
    }

}


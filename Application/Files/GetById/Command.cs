using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Files;

public partial class FileDataRequest : IRequest<FileData>
{
    public class Handler : IRequestHandler<FileDataRequest, FileData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<FileData> Handle(FileDataRequest request, CancellationToken cancellationToken)
        {
            var file = await _dbContext.Files.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken) ??
                throw new Exception("file not found");

            return _mapper.Map<FileData>(file);

        }
    }

}


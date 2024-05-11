using AutoMapper;
using DataAccess;
using MediatR;

namespace MySpace.Application.Files;
public partial class NewFile : IRequest<FileData>
{
    public class Handler : IRequestHandler<NewFile, FileData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<FileData> Handle(NewFile request, CancellationToken cancellationToken)
        {
            var file = _mapper.Map<Domain.File>(request);

            await _dbContext.Files.AddAsync(file, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<FileData>(file);

        }
    }

}


using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Files;

public partial class EditFileData : IRequest<FileData>
{
    public class Handler : IRequestHandler<EditFileData, FileData>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<FileData> Handle(EditFileData request, CancellationToken cancellationToken)
        {
           
            var FileReq = await _dbContext.Files.FirstOrDefaultAsync(s => s.Id == request.Id) ??
              throw new RpcException(new Status(StatusCode.Cancelled, "Edit File Failed!"));

            _mapper.Map(request, FileReq);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return _mapper.Map<FileData>(FileReq);


        }

    }
}
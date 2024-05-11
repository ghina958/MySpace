using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Files;
//public partial class ListFileDataRequest : IRequest<ListFilesData>
//{
//    public class Handler : IRequestHandler<ListFileDataRequest, ListFilesData>
//    {
//        private readonly ApplicationDbContext _dbContext;
//        private readonly IMapper _mapper;
//        public Handler(ApplicationDbContext dbContext, IMapper mapper)
//        {
//            _dbContext = dbContext;
//            _mapper = mapper;
//        }
//        public async Task<ListFilesData> Handle(ListFileDataRequest request, CancellationToken cancellationToken)
//        {
//            var files = await _dbContext.Files.ToListAsync();
//            return new ListFilesData()
//            {
//                File = { _mapper.Map<List<FileData>>(files) }

//            };

//        }
//    }

//}

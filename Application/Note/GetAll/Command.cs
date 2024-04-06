using AutoMapper;
using DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;
//public partial class GetAllNotesRequest : IRequest<GetAllNotesResponse>
//{
//    public class Handler : IRequestHandler<GetAllNotesRequest, GetAllNotesResponse>
//    {
//        private readonly ApplicationDbContext _dbContext;
//        private readonly IMapper _mapper;

//        public Handler(ApplicationDbContext dbContext, IMapper mapper)
//        {
//            _dbContext = dbContext;
//            _mapper = mapper;
//        }
//        public async Task<GetAllNotesResponse> Handle(GetAllNotesRequest request, CancellationToken cancellationToken)
//        {
//           var response=new GetAllNotesResponse();
//            var note = await _dbContext.Notes.ToListAsync();
//            foreach (var item in note)
//            {
//                var mapp = _mapper.Map<GetNoteByIdResponse>(item);
//                response.Note.Add(mapp);
//            }
//            return await Task.FromResult(response);

//        }
//    }

//}



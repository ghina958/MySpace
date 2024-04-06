using AutoMapper;
using DataAccess;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Application.Note;
public partial class CreateNoteRequest : IRequest<CreateNoteResponse>
{
    public class Handler : IRequestHandler<CreateNoteRequest, CreateNoteResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CreateNoteResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
        {
                var note = _mapper.Map<Domain.Note>(request);
               
                await _dbContext.Notes.AddAsync(note, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
              
                return _mapper.Map<CreateNoteResponse>(note);
            
        }
    }

}


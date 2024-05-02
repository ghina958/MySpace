using AutoMapper;
using DataAccess;
using Grpc.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySpace.Application.Category;

namespace MySpace.Application.Attachment;
public partial class CreateAttachmentRequest : IRequest<AttachmentResponse>
{
    //public class Handler : IRequestHandler<CreateAttachmentRequest, AttachmentResponse>
    //{
    //    private readonly ApplicationDbContext _dbContext;
    //    private readonly IMapper _mapper;

    //    public Handler(ApplicationDbContext dbContext, IMapper mapper)
    //    {
    //        _dbContext = dbContext;
    //        _mapper = mapper;
    //    }
    //    public async Task<AttachmentResponse> Handle(CreateAttachmentRequest request, CancellationToken cancellationToken)
    //    {
    //        try
    //        {
    //            var exitingFile = await _dbContext.Files.FirstOrDefaultAsync(f => f.Id == request.FileId);
    //            if (exitingFile == null)
    //            {
    //                throw new RpcException(new Status(StatusCode.Cancelled, "Edit Order Failed!"));

    //            }
    //            else
    //            {
    //                _mapper.Map(request, exitingFile);
    //                await _dbContext.SaveChangesAsync(cancellationToken);
    //                return _mapper.Map<EditCategoryResponse>(exitingFile);

    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //            throw new RpcException(new Status(StatusCode.Internal, $"Failed to edit category: {ex.Message}"));

    //        }
    //    }
    //}

}

using Grpc.Core;
using MediatR;
using MySpace.Application.Category;

namespace MySpace.WebAPI.Services;
internal class CategoryService : Categories.CategoriesBase
{
    private readonly IMediator _mediator;

    public CategoryService(IMediator mediator)
    {
        _mediator = mediator;
    }
    //public override async Task<CreateCategoryResponse> CreateCategory(CreateCategoryRequest request, ServerCallContext context)
    //{
    //    return await _mediator.Send(request);
    //}
    public override async Task<GetByIdResponse> GetByIdCategory(GetByIdRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<EditCategoryResponse> EditCategory(EditCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<DeleteCategoryResponse> DeleteCategory(DeleteCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<GetAllCategoriesResponse> ListAll(GetAllCategoriesRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

}

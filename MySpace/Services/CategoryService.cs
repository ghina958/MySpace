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
    public override async Task<CategoryData> Create(NewCategory request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<OneCategoryData> GetById(CategoryDataRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

    public override async Task<CategoryData> Edit(EditCategory request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<DeleteCategory> Delete(DeleteCategoryRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }
    public override async Task<ListCategories> ListAll(ListCategoriesRequest request, ServerCallContext context)
    {
        return await _mediator.Send(request);
    }

}

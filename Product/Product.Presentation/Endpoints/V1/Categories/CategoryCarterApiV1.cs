using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Product.Application.Features.Category.Commands.CreateCategory;
using Product.Application.Features.Category.Commands.DeleteCategory;
using Product.Application.Features.Category.Commands.UpdateCategory;
using Product.Application.Features.Category.Queries.GetCategories;

namespace Product.Presentation.Endpoints.V1.Categories
{
    public class CategoryCarterApiV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/categories";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("category-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, Get);
            group1.MapPost(string.Empty, Create);
            group1.MapPut("{id}", Update);
            group1.MapDelete("{id}", Delete);
        }

        public async Task<IResult> Get(ISender sender)
        {
            var category = await sender.Send(new GetCategoriesQuery());

            if (category.Count <= 0)
            {
                return Results.NotFound();
            }

            return Results.Ok(category);
        }

        public async Task<IResult> Create(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] CreateCategoryCommand command)
        {
            command.CreatedBy = userId;
            await sender.Send(command);
            return Results.Ok("Create category successful");
        }

        public async Task<IResult> Update(ISender sender, int id, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            command.LastModifiedBy = userId;
            await sender.Send(command);
            return Results.Ok("Update category successful");
        }

        public async Task<IResult> Delete(ISender sender, int id, [FromHeader(Name = "X-User-Id")] Guid userId)
        {
            await sender.Send(new DeleteCategoryCommand { Id = id, UserId = userId });
            return Results.Ok("Delete category successful");
        }
    }
}

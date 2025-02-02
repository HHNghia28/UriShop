using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Features.Order.Commands.CancelOrder;
using Order.Application.Features.Order.Commands.CreateOrder;
using Order.Application.Features.Order.Commands.UpdateOrder;
using Order.Application.Features.Order.Queries.GetOrder;
using Order.Application.Features.Order.Queries.GetOrders;
using Order.Application.Features.Order.Queries.GetOrdersByUserId;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Order.API.Endpoints.V1.Orders
{
    public class OrdersCarterV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/orders";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("order-carter-name-show-on-swagger")
            .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet(string.Empty, GetAll);
            group1.MapGet("{id}", Get);
            group1.MapGet("user", GetAllByUserId);
            group1.MapPost(string.Empty, Create);
            group1.MapPut("{id}", Update);
            group1.MapPut("cancel/{id}", Cancel);
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetOrdersQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        public async Task<IResult> Get(ISender sender, Guid id)
        {
            return Results.Ok(await sender.Send(new GetOrderQuery { Id = id }));
        }

        public async Task<IResult> GetAllByUserId(ISender sender, [FromQuery] Guid userId, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetOrdersByUserIdQuery { PageNumber = pageNumber, PageSize = pageSize, UserId = userId }));
        }

        public async Task<IResult> Create(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] CreateOrderCommand request)
        {
            request.CreatedBy = userId;
            await sender.Send(request);
            return Results.Ok("Create order successful");
        }

        public async Task<IResult> Update(ISender sender, Guid id, [FromHeader(Name = "X-User-Id")] Guid userId, [FromBody] UpdateOrderCommand request)
        {
            request.Id = id;
            request.LastModifiedBy = userId;
            await sender.Send(request);
            return Results.Ok("Update order successful");
        }

        public async Task<IResult> Cancel(ISender sender, Guid id, [FromHeader(Name = "X-User-Id")] Guid userId)
        {
            await sender.Send(new CancelOrderCommand { Id = id, LastModifiedBy = userId });
            return Results.Ok("Cancel order successful");
        }
    }
}
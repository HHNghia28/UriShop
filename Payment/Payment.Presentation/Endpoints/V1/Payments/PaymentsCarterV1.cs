using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Payment.Application.Features.Payment.Commands.CreatePaymentOrder;
using Payment.Application.Features.Payment.Commands.OrderPaymentByPayOSReturn;
using Payment.Application.Features.Payment.Queries.GetPayments;

namespace Payment.Presentation.Endpoints.V1.Payments
{
    public class PaymentsCarterV1 : ICarterModule
    {
        private const string BaseUrl = "api/v{version:apiVersion}/payments";

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group1 = app.NewVersionedApi("payment-carter-name-show-on-swagger")
                .MapGroup(BaseUrl)
                .HasApiVersion(1);

            group1.MapGet("get-all", GetAll);
            group1.MapPost("order-payment-by-payos", CreateOrderPaymentByPayOS);
            group1.MapGet("order-payment-by-payos-return", OrderPaymentByPayOSReturn);
        }

        public async Task<IResult> GetAll(ISender sender, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1)
        {
            return Results.Ok(await sender.Send(new GetPaymentsQuery { PageNumber = pageNumber, PageSize = pageSize }));
        }

        public async Task<IResult> CreateOrderPaymentByPayOS(ISender sender, [FromHeader(Name = "X-User-Id")] Guid userId,
            [FromBody] CreateOrderPaymentByPayOSCommand request)
        {
            request.CreatedById = userId;
            var link = await sender.Send(request);
            return Results.Ok(link);
        }

        public async Task<IResult> OrderPaymentByPayOSReturn(ISender sender,
        [FromQuery] string code,
        [FromQuery] string id,
        [FromQuery] string cancel,
        [FromQuery] string status,
        [FromQuery] string orderCode)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(orderCode))
            {
                return Results.BadRequest(new
                {
                    Message = "Invalid query parameters",
                    Success = false
                });
            }

            var clientRedirect = await sender.Send(new OrderPaymentByPayOSReturnCommand()
            {
                OrderCode = orderCode,
                Status = status,
                Code = code,
                Id = id,
                Cancel = cancel
            });

            return Results.Redirect(clientRedirect);
        }
    }
}

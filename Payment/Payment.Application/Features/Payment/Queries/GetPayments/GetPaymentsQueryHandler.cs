using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.DTO;
using Payment.Application.Interfaces;
using Payment.Application.Wrappers;

namespace Payment.Application.Features.Payment.Queries.GetPayments
{
    public class GetPaymentsQueryHandler(IPaymentRepository _paymentRepository) 
        : IRequestHandler<GetPaymentsQuery, PagedResponse<List<PaymentResponse>>>
    {
        public async Task<PagedResponse<List<PaymentResponse>>> Handle(GetPaymentsQuery request, CancellationToken cancellationToken)
        {
            return await _paymentRepository.GetPayments(new PagedRequest()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            });
        }
    }
}

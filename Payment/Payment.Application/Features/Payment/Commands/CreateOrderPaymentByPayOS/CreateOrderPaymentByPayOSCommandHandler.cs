using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.Exceptions;
using Payment.Application.Interfaces;
using Payment.Infrastructure.PayOS.DTO;
using Payment.Infrastructure.PayOS.Services;

namespace Payment.Application.Features.Payment.Commands.CreatePaymentOrder
{
    public class CreateOrderPaymentByPayOSCommandHandler(IPaymentRepository _paymentRepository, 
                IPayOSService _payOSService)
                : IRequestHandler<CreateOrderPaymentByPayOSCommand, string>
    {
        public async Task<string> Handle(CreateOrderPaymentByPayOSCommand request, CancellationToken cancellationToken)
        {
            string paymentLink = "";

            var payment = await _paymentRepository.GetByIdAsync(request.OrderId);

            if (payment != null)
            {
                if (payment.Status == Domain.Enums.PaymentStatus.PAIDED) throw new InvalidOperationException("Order paided");

                if (!payment.PaymentLink.Equals("")) return payment.PaymentLink;
            }

            paymentLink = await _payOSService.CreatePaymentAsync(new CreatePaymentDTO()
            {
                OrderCode = request.OrderId,
                Content = request.OrderId.ToString(),
                RequiredAmount = request.RequiredAmount,
            });

            await _paymentRepository.AddAsync(new Domain.Entities.Payment()
            {
                Id = request.OrderId,
                AmountCharged = request.RequiredAmount,
                PaymentLink = paymentLink,
                CreatedById = request.CreatedById,
                LastModifiedById = request.CreatedById,
            });

            await _paymentRepository.SaveAsync();

            return paymentLink;
        }
    }
}

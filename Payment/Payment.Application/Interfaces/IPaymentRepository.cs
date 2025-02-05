using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.DTO;
using Payment.Application.Interfaces;
using Payment.Application.Wrappers;
using Payment.Domain.Entities;

namespace Payment.Application.Interfaces
{
    public interface IPaymentRepository : IRepository<Domain.Entities.Payment>
    {
        Task<PagedResponse<List<PaymentResponse>>> GetPayments(PagedRequest request);
        Task<List<Domain.Entities.Payment>> GetExpiredsPayments();
    }
}

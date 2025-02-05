using Payment.Infrastructure.PayOS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.PayOS.Services
{
    public interface IPayOSService
    {
        Task<string> CreatePaymentAsync(CreatePaymentDTO createPaymentDTO);
    }
}

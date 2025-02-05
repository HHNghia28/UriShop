using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Enums;

namespace Payment.Application.DTO
{
    public class PaymentResponse
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public int AmountCharged { get; set; }
        public DateTime TimeCharge { get; set; }
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
    }
}

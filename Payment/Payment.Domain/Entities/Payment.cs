using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Domain.Common;
using Payment.Domain.Enums;
using Payment.Domain.Shares;

namespace Payment.Domain.Entities
{
    public class Payment : AuditableBaseEntity<long>
    {
        public int AmountCharged { get; set; }
        public DateTime TimeCharge { get; set; } = DateUtility.GetCurrentDateTime();
        public PaymentStatus Status { get; set; } = PaymentStatus.PENDING;
        public string PaymentLink { get; set; }
    }
}

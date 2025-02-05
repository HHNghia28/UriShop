using Payment.Domain.Shares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Common
{
    public abstract class AuditableBaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedAt { get; set; } = DateUtility.GetCurrentDateTime();
        public Guid LastModifiedById { get; set; }
        public DateTime? LastModifiedAt { get; set; } = DateUtility.GetCurrentDateTime();
    }
}

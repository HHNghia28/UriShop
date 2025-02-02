using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Domain.Common
{
    public abstract class AuditableBaseEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; } = DateTime.UtcNow;
    }
}

using UriStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Product : AuditableBaseEntity<Guid>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        [StringLength(500)]
        public string Photo { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

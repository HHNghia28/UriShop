using Order.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Domain.Entities
{
    public class Category : AuditableBaseEntity<int>
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}

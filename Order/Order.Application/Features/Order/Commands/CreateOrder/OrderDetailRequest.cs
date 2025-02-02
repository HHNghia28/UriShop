using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.CreateOrder
{
    public class OrderDetailRequest
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        [StringLength(500)]
        public string Photo { get; set; }
        public string Category { get; set; }
        public Guid ProductId { get; set; }
    }
}

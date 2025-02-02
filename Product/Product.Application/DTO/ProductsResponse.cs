using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.DTO
{
    public class ProductsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Quantity { get; set; } = 0;
        public string Photo { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int Price { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int Stock { get; set; } = 0;
        [StringLength(500)]
        public string Photo { get; set; }

        [JsonIgnore]
        public Guid LastModifiedBy { get; set; }
        public int CategoryId { get; set; }
    }
}

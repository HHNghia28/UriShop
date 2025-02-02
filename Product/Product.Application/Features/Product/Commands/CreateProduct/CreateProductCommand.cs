using MediatR;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest
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

        [JsonIgnore]
        public Guid CreatedBy { get; set; }
        public int CategoryId { get; set; }
    }
}

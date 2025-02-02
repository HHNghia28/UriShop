using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<long>
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(10)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(500)]
        public string Address { get; set; }
        [Required]
        [StringLength(500)]
        public string? Note { get; set; }
        public int ShippingFee { get; set; } = 0;
        public int DiscountFee { get; set; } = 0;
        [StringLength(100)]
        public string? VoucherName { get; set; }
        [StringLength(100)]
        public string? VoucherCode { get; set; }
        public int VoucherValue { get; set; } = 0;
        public List<OrderDetailRequest> Details { get; set; }

        [JsonIgnore]
        public Guid CreatedBy { get; set; }
    }
}

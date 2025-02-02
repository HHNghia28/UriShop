using Order.Domain.Common;
using Order.Domain.Entities;
using Order.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.DTO
{
    public class OrderResponse
    {
        public long Id { get; set; }
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
        public int TotalPrice { get; set; } = 0;
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public ICollection<OrderDetailResponse> Details { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; } = DateTime.UtcNow;
    }
}

using Order.Domain.Enums;
using Order.Domain.Shares;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.DTO
{
    public class OrdersResponse
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
        public int TotalPrice { get; set; } = 0;
        public OrderStatus Status { get; set; } = OrderStatus.PENDING;
        public DateTime CreatedAt { get; set; } = DateUtility.GetCurrentDateTime();
        public DateTime? LastModifiedAt { get; set; } = DateUtility.GetCurrentDateTime();
    }
}

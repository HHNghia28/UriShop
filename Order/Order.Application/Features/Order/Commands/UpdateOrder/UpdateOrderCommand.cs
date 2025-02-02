using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Order.Application.Features.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

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
        [JsonIgnore]
        public Guid LastModifiedBy { get; set; }
    }
}

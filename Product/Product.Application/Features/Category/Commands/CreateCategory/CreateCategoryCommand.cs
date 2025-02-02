using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        [JsonIgnore]
        public Guid CreatedBy { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

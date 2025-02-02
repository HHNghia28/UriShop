using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }
        public Guid UserId { get; set; }
    }
}

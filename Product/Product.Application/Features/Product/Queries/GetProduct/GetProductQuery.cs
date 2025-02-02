using MediatR;
using Product.Application.DTO;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
    }
}

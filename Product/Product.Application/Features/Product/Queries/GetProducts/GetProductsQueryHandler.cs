using Dapper;
using MediatR;
using Product.Application.DTO;
using Product.Application.Interfaces;
using Product.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository productRepository) : IRequestHandler<GetProductsQuery, PagedResponse<List<ProductsResponse>>>
    {
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<PagedResponse<List<ProductsResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProducts(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
        }
    }
}

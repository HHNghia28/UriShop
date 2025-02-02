using Product.Application.DTO;
using Product.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface IProductRepository : IRepository<Domain.Entities.Product>
    {
        Task<PagedResponse<List<ProductsResponse>>> GetProducts(PagedRequest request);
        Task<ProductResponse> GetProduct(Guid id);
    }
}

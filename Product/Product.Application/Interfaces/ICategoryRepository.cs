using Product.Application.DTO;
using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<CategoryResponse>> GetCategories();
    }
}

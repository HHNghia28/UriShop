using Product.Domain.Entities;
using Product.Application.Interfaces;
using Product.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Product.Application.DTO;
using Dapper;

namespace Product.Infrastructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context, ISqlConnectionFactory sqlConnectionFactory) : Repository<Category>(context), ICategoryRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory = sqlConnectionFactory;

        public async Task<List<CategoryResponse>> GetCategories()
        {
            var connection = _sqlConnectionFactory.GetOpenConnection();
            const string categoriesQuery = @"
                    SELECT
                        ""Categories"".""Id"",
                        ""Categories"".""Name""
                    FROM ""Categories""
                    WHERE ""Categories"".""IsDeleted"" = false
                ";

            var categories = await connection.QueryAsync<CategoryResponse>(categoriesQuery);
            return categories.AsList();
        }
    }
}

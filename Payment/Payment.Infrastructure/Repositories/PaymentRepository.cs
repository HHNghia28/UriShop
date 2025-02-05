using Dapper;
using Microsoft.EntityFrameworkCore;
using Payment.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.DTO;
using Payment.Application.Wrappers;
using Payment.Domain.Entities;
using Payment.Domain.Shares;
using Payment.Infrastructure.Context;

namespace Payment.Infrastructure.Repositories
{
    public class PaymentRepository(ApplicationDbContext _context, ISqlConnectionFactory _sqlConnectionFactory) 
        : Repository<Domain.Entities.Payment>(_context), IPaymentRepository
    {
        public async Task<List<Domain.Entities.Payment>> GetExpiredsPayments()
        {
            return await _context.Payments.Where(p => p.Status == Domain.Enums.PaymentStatus.PENDING
                && p.LastModifiedAt.HasValue && p.LastModifiedAt.Value.AddMinutes(5) < DateUtility.GetCurrentDateTime())
                .ToListAsync();
        }

        public async Task<PagedResponse<List<PaymentResponse>>> GetPayments(PagedRequest request)
        {
            using var connection = _sqlConnectionFactory.GetOpenConnection();
            const string sqlPayments = @"
                    SELECT 
                        ""Payments"".""Id"",
                        ""Payments"".""AmountCharged"",
                        ""Payments"".""CreatedById"" as ""UserId"",
                        ""Payments"".""TimeCharge"",
                        ""Payments"".""Status""
                    FROM ""Payments""
                    ORDER BY ""Payments"".""LastModifiedAt"" DESC
                    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var offset = (request.PageNumber - 1) * request.PageSize;
            var products = await connection.QueryAsync<PaymentResponse>(sqlPayments, new { Offset = offset, PageSize = request.PageSize });

            const string sqlCount = @"
                    SELECT COUNT(*)
                    FROM ""Payments""";

            var totalRecords = await connection.ExecuteScalarAsync<int>(sqlCount);

            var response = new PagedResponse<List<PaymentResponse>>(
                products.AsList(),
                request.PageNumber,
                request.PageSize,
                (int)Math.Ceiling((double)totalRecords / request.PageSize)
            );

            return response;
        }
    }
}

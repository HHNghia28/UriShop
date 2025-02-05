using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment.Application.Interfaces;

namespace Payment.Infrastructure.Backgrounds
{
    public class PaymentCleanupService(IServiceScopeFactory _scopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var paymentRepository = scope.ServiceProvider.GetRequiredService<IPaymentRepository>();

                        var expiredPayments = await paymentRepository.GetExpiredsPayments();

                        foreach (var item in expiredPayments)
                        {
                            item.Status = Domain.Enums.PaymentStatus.CANCEL;
                            await paymentRepository.UpdateAsync(item);
                        }

                        await paymentRepository.SaveAsync();
                    }

                    await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred in OrderCleanupService: {ex.Message}");
                }
            }
        }
    }
}

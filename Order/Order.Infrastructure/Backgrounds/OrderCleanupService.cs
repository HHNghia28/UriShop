using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using Order.Application.Interfaces;

namespace Order.Infrastructure.Backgrounds
{
    public class OrderCleanupService(IServiceScopeFactory _scopeFactory) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var orderRepository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                        //var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

                        var expiredOrders = await orderRepository.GetExpiredOrders();

                        foreach (var expiredOrder in expiredOrders)
                        {
                            expiredOrder.Status = Domain.Enums.OrderStatus.CANCEL;
                            await orderRepository.UpdateAsync(expiredOrder);

                            //foreach (var detail in expiredOrder.Details)
                            //{
                            //    detail.Product.Stock += detail.Quantity;
                            //    await productRepository.UpdateAsync(detail.Product);
                            //}
                        }

                        await orderRepository.SaveAsync();
                    }

                    await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred in OrderCleanupService: {ex.Message}");
                }
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Order.api.Context;
using Order.api.Interfaces;
using Order.Models.Entity;

namespace Order.api.Repositories
{
    public class SalesOrderRepository: ISalesOrderRepositories
    {
        private readonly AppDBContext appDbContext;
        public SalesOrderRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<SalesOrder>> GetSalesOrders()
        {
            return await appDbContext.SalesOrders.ToListAsync();
        }

        public async Task<SalesOrder> GetSalesOrder(int salesOrderId)
        {
            return await appDbContext.SalesOrders
                .FirstOrDefaultAsync(e => e.ID == salesOrderId);
        }

        public async Task AddSalesOrder(SalesOrder salesOrder)
        {
            var result = await appDbContext.SalesOrders.AddAsync(salesOrder);
            await appDbContext.SaveChangesAsync();
        }

        public async Task UpdateSalesOrder(SalesOrder salesOrder)
        {
            var result = await appDbContext.SalesOrders
                .FirstOrDefaultAsync(e => e.ID == salesOrder.ID);

            if (result != null)
            {
                result.Name = salesOrder.Name;
                result.State = salesOrder.State;

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSalesOrder(int salesOrderId)
        {
            var result = await appDbContext.SalesOrders
                .FirstOrDefaultAsync(e => e.ID == salesOrderId);
            if (result != null)
            {
                appDbContext.SalesOrders.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}

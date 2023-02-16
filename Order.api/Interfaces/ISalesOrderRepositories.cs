using Order.Models.Entity;

namespace Order.api.Interfaces
{
    public interface ISalesOrderRepositories
    {
        Task<IEnumerable<SalesOrder>> GetSalesOrders();
        Task<SalesOrder> GetSalesOrder(int salesOrderId);
        Task AddSalesOrder(SalesOrder salesOrder);
        Task UpdateSalesOrder(SalesOrder salesOrder);
        Task DeleteSalesOrder(int id);
    }
}

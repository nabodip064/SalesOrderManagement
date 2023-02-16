using Order.Models.DTO;

namespace Order.web.Bases.Interfaces
{
    public interface ISalesOrderService
    {
        Task<IEnumerable<SalesOrderDto>> GetSalesOrders();
        Task<SalesOrderDto> GetSalesOrder(int salesOrderId);
        Task AddSalesOrder(SalesOrderDto salesOrder);
        Task UpdateSalesOrder(SalesOrderDto salesOrder);
        Task DeleteSalesOrder(int id);
    }
}

using Newtonsoft.Json;
using Order.Models.DTO;
using Order.web.Bases.Interfaces;
using System.Net.Http.Json;
using System.Text;

namespace Order.web.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private readonly HttpClient httpClient;

        public SalesOrderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddSalesOrder(SalesOrderDto salesOrder)
        {
            await httpClient.PostAsJsonAsync<SalesOrderDto>("api/SalesOrders", salesOrder);
        }

        public async Task DeleteSalesOrder(int id)
        {
            await httpClient.DeleteAsync($"api/SalesOrders/{id}");
        }

        public async Task<SalesOrderDto> GetSalesOrder(int id)
        {
            return await httpClient.GetFromJsonAsync<SalesOrderDto>($"api/SalesOrders/{id}");
        }

        public async Task<IEnumerable<SalesOrderDto>> GetSalesOrders()
        {
            return await httpClient.GetFromJsonAsync<SalesOrderDto[]>("api/SalesOrders");
        }

        public async Task UpdateSalesOrder(SalesOrderDto salesOrder)
        {
            await httpClient.PutAsJsonAsync<SalesOrderDto>("api/SalesOrders", salesOrder);
        }
    }
}

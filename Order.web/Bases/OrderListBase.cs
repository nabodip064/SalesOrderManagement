using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class OrderListBase : ComponentBase
    {
        [Inject]
        public ISalesOrderService OrderService { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public IEnumerable<SalesOrderDto> SalesOrders { get; set; } = Enumerable.Empty<SalesOrderDto>();
        protected override async Task OnInitializedAsync()
        {
            SalesOrders = (await OrderService.GetSalesOrders());
        }
        protected async Task ActionDelete(int id)
        {
            bool isConfirm = await Js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await OrderService.DeleteSalesOrder(id);
                await OnInitializedAsync();
            }
        }
    }
}

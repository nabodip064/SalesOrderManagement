using Microsoft.AspNetCore.Components;
using Order.Models.DTO;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class OrderSaveBase : ComponentBase
    {
        public SalesOrderDto SalesOrder { get; set; } = new SalesOrderDto();

        [Inject]
        public ISalesOrderService SalesOrderService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id == null)
                SalesOrder = new SalesOrderDto();
            else
                SalesOrder = await SalesOrderService.GetSalesOrder((int)Id);
        }
        protected async Task HandleValidSubmit()
        {
            if (SalesOrder.ID != 0)
                await SalesOrderService.UpdateSalesOrder(SalesOrder);
            else
                await SalesOrderService.AddSalesOrder(SalesOrder);
            NavigationManager.NavigateTo("/");
        }
    }
}

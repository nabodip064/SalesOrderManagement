using Microsoft.AspNetCore.Components;
using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class WindowSaveBase : ComponentBase
    {
        public WindowDto Window { get; set; } = new WindowDto();
        public IEnumerable<SalesOrderDto> SalesOrders { get; set; } = Enumerable.Empty<SalesOrderDto>();

        [Inject]
        public IWindowService WindowService { get; set; }
        [Inject]
        public ISalesOrderService SaleOrderService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (Id == null)
                Window = new WindowDto();
            else
                Window = await WindowService.GetWindow((int)Id);
            SalesOrders = await SaleOrderService.GetSalesOrders();
        }
        protected async Task HandleValidSubmit()
        {
            if (Window.ID != 0)
                await WindowService.UpdateWindow(Window);
            else
                await WindowService.AddWindow(Window);
            NavigationManager.NavigateTo("/window/list");
        }
    }
}

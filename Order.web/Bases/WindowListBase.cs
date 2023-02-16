using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class WindowListBase : ComponentBase
    {
        [Inject]
        public IWindowService WindowService { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public IEnumerable<WindowDto> Windows { get; set; } = Enumerable.Empty<WindowDto>();
        protected override async Task OnInitializedAsync()
        {
            Windows = (await WindowService.GetWindows());
        }
        protected async Task ActionDelete(int id)
        {
            bool isConfirm = await Js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await WindowService.DeleteWindow(id);
                await OnInitializedAsync();
            }
        }
    }
}

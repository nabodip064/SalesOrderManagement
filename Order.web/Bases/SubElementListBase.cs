using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class SubElementListBase : ComponentBase
    {
        [Inject]
        public ISubElementService SubElementService { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public IEnumerable<SubElementDto> SubElementDtos { get; set; } = new List<SubElementDto>();
        [Parameter]
        public int? WindowId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            if(WindowId == null)
                SubElementDtos = (await SubElementService.GetSubElements());
            else
                SubElementDtos = (await SubElementService.GetSubElementByWindow((int)WindowId));
        }
        protected async Task ActionDelete(int id)
        {
            bool isConfirm = await Js.InvokeAsync<bool>("confirm", "Do you sure to delete this?");
            if (isConfirm)
            {
                await SubElementService.DeleteSubElement(id);
                await OnInitializedAsync();
            }
        }
    }
}

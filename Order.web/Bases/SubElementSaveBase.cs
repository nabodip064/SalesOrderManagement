using Microsoft.AspNetCore.Components;
using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;

namespace Order.web.Bases
{
    public class SubElementSaveBase: ComponentBase
    {
        public SubElementDto SubElementItem { get; set; } = new SubElementDto();
        [Inject]
        public IWindowService WindowService { get; set; }
        [Inject]
        public ISubElementService SubElementService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public int? Id { get; set; }
        public IEnumerable<WindowDto> Windows { get; set; } = new List<WindowDto>();

        protected override async Task OnInitializedAsync()
        {
            if (Id == null)
                SubElementItem = new SubElementDto();
            else
                SubElementItem = await SubElementService.GetSubElement((int)Id);
            Windows = (await WindowService.GetWindows());
        }
        protected async Task HandleValidSubmit()
        {
            if (SubElementItem.ID != 0)
                await SubElementService.UpdateSubElement(SubElementItem);
            else
                await SubElementService.AddSubElement(SubElementItem);
            NavigationManager.NavigateTo("/subelement/list");
        }
    }
}

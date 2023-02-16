using Order.Models.DTO;
using Order.Models.Entity;

namespace Order.web.Bases.Interfaces
{
    public interface IWindowService
    {
        Task<IEnumerable<WindowDto>> GetWindows();
        Task<WindowDto> GetWindow(int windowId);
        Task AddWindow(WindowDto window);
        Task UpdateWindow(WindowDto window);
        Task DeleteWindow(int windowId);
    }
}

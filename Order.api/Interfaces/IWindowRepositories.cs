using Order.Models.Entity;

namespace Order.api.Interfaces
{
    public interface IWindowRepositories
    {
        Task<IEnumerable<Window>> GetWindows();
        Task<Window> GetWindow(int windowId);
        Task AddWindow(Window window);
        Task UpdateWindow(Window window);
        Task DeleteWindow(int windowId);
    }
}

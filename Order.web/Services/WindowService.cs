using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;
using System.Net.Http.Json;

namespace Order.web.Services
{
    public class WindowService : IWindowService
    {
        private readonly HttpClient httpClient;

        public WindowService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddWindow(WindowDto window)
        {
            await httpClient.PostAsJsonAsync<WindowDto>("api/Windows", window);
        }

        public async Task DeleteWindow(int id)
        {
            await httpClient.DeleteAsync($"api/Windows/{id}");
        }

        public async Task<WindowDto> GetWindow(int id)
        {
            return await httpClient.GetFromJsonAsync<WindowDto>($"api/Windows/{id}");
        }

        public async Task<IEnumerable<WindowDto>> GetWindows()
        {
            return await httpClient.GetFromJsonAsync<WindowDto[]>("api/Windows");
        }

        public async Task UpdateWindow(WindowDto window)
        {
            await httpClient.PutAsJsonAsync<WindowDto>("api/Windows", window);
        }
    }
}

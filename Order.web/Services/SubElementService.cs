using Order.Models.DTO;
using Order.Models.Entity;
using Order.web.Bases.Interfaces;
using System.Net.Http.Json;

namespace Order.web.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly HttpClient httpClient;

        public SubElementService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task AddSubElement(SubElementDto subElement)
        {
            await httpClient.PostAsJsonAsync<SubElementDto>("api/SubElements", subElement);
        }

        public async Task DeleteSubElement(int id)
        {
            await httpClient.DeleteAsync($"api/SubElements/{id}");
        }

        public async Task<SubElementDto> GetSubElement(int id)
        {
            return await httpClient.GetFromJsonAsync<SubElementDto>($"api/SubElements/{id}");
        }

        public async Task<IEnumerable<SubElementDto>> GetSubElements()
        {
            return await httpClient.GetFromJsonAsync<SubElementDto[]>("api/SubElements");
        }

        public async Task UpdateSubElement(SubElementDto subElement)
        {
            await httpClient.PutAsJsonAsync<SubElementDto>("api/SubElements", subElement);
        }
        public async Task<IEnumerable<SubElementDto>> GetSubElementByWindow(int windowId)
        {
            return await httpClient.GetFromJsonAsync<SubElementDto[]>($"api/SubElements/searchByWindow/{windowId}");
        }
    }
}

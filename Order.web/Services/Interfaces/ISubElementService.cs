using Order.Models.DTO;
using Order.Models.Entity;

namespace Order.web.Bases.Interfaces
{
    public interface ISubElementService
    {
        Task<IEnumerable<SubElementDto>> GetSubElementByWindow(int windowId);
        Task<IEnumerable<SubElementDto>> GetSubElements();
        Task<SubElementDto> GetSubElement(int subElementId);
        Task AddSubElement(SubElementDto subElement);
        Task UpdateSubElement(SubElementDto subElement);
        Task DeleteSubElement(int id);
    }
}

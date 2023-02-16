using Order.Models.Entity;

namespace Order.api.Interfaces
{
    public interface ISubElementRepositories
    {
        Task<IEnumerable<SubElement>> GetSubElements();
        Task<IEnumerable<SubElement>> GetSubElementByWindow(int windowId);
        Task<SubElement> GetSubElement(int subElementId);
        Task AddSubElement(SubElement subElement);
        Task UpdateSubElement(SubElement subElement);
        Task DeleteSubElement(int id);
    }
}

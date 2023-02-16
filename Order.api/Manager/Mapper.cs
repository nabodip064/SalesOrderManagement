using Order.api.Interfaces;
using Order.Models.DTO;
using Order.Models.Entity;

namespace Order.api.Manager
{
    public class Mapper
    {
        public async Task<WindowDto> MapWindowDto(Window window, ISubElementRepositories subElementRepositories)
        {
            List<SubElement> sebElementByWindowList = (List<SubElement>)(await subElementRepositories.GetSubElementByWindow(window.ID));
            return new WindowDto { 
                ID = window.ID, 
                Name = window.Name, 
                SalesOrderID = window.SalesOrderID, 
                QuantityOfWindows = window.QuantityOfWindows, 
                TotalSubElements = sebElementByWindowList.Count 
            };
        }

        public async Task<SubElementDto> MapSubElementDto(SubElement subElement)
        {
            return new SubElementDto
            {
                ID = subElement.ID,
                Element = subElement.Element,
                Height = subElement.Height,
                Width = subElement.Width,
                Type = subElement.Type,
                WindowID = subElement.WindowID
            };
        }
        public async Task<Window> MapWindow(WindowDto windowDto)
        {

            return new Window
            {
                ID = windowDto.ID,
                Name = windowDto.Name,
                QuantityOfWindows = windowDto.QuantityOfWindows,
                SalesOrderID = windowDto.SalesOrderID
            };
        }
        public async Task<SubElement> MapSubElement(SubElementDto subElementDto)
        {

            return new SubElement
            {
                ID = subElementDto.ID,
                Type = subElementDto.Type, 
                Width = subElementDto.Width, 
                Height = subElementDto.Height, 
                WindowID = subElementDto.WindowID, 
                Element = subElementDto.Element 
            };
        }
    }
}

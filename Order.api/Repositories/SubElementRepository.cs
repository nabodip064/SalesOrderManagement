using Microsoft.EntityFrameworkCore;
using Order.api.Context;
using Order.api.Interfaces;
using Order.Models.Entity;

namespace Order.api.Repositories
{
    public class SubElementRepository: ISubElementRepositories
    {
        private readonly AppDBContext appDbContext;
        public SubElementRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<SubElement>> GetSubElements()
        {
            return await appDbContext.SubElements.ToListAsync();
        }

        public async Task<SubElement> GetSubElement(int subElementId)
        {
            return await appDbContext.SubElements.Include(e => e.WindowItem)
                .FirstOrDefaultAsync(e => e.ID == subElementId);
        }

        public async Task AddSubElement(SubElement subElement)
        {
            var result = await appDbContext.SubElements.AddAsync(subElement);
            await appDbContext.SaveChangesAsync();
        }

        public async Task UpdateSubElement(SubElement subElement)
        {
            var result = await appDbContext.SubElements
                .FirstOrDefaultAsync(e => e.ID == subElement.ID);

            if (result != null)
            {
                result.Type = subElement.Type;
                result.Element = subElement.Element;
                result.Width = subElement.Width;
                result.Height = subElement.Height;
                result.WindowID = subElement.WindowID;

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteSubElement(int subElementId)
        {
            var result = await appDbContext.SubElements
                .FirstOrDefaultAsync(e => e.ID == subElementId);
            if (result != null)
            {
                appDbContext.SubElements.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SubElement>> GetSubElementByWindow(int windowId)
        {
            return await appDbContext.SubElements.Include(e => e.WindowItem)
                .Where(e => e.WindowID == windowId).ToListAsync();
        }
    }
}

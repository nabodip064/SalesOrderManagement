using Microsoft.EntityFrameworkCore;
using Order.api.Context;
using Order.api.Interfaces;
using Order.Models.Entity;

namespace Order.api.Repositories
{
    public class WindowRepository: IWindowRepositories
    {
        private readonly AppDBContext appDbContext;
        public WindowRepository(AppDBContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Window>> GetWindows()
        {
            return await appDbContext.Windows.ToListAsync();
        }

        public async Task<Window> GetWindow(int windowId)
        {
            return await appDbContext.Windows.Include(e => e.SalesOrderItem)
                .FirstOrDefaultAsync(e => e.ID == windowId);
        }

        public async Task AddWindow(Window window)
        {
            var result = await appDbContext.Windows.AddAsync(window);
            await appDbContext.SaveChangesAsync();
        }

        public async Task UpdateWindow(Window window)
        {
            var result = await appDbContext.Windows
                .FirstOrDefaultAsync(e => e.ID == window.ID);

            if (result != null)
            {
                result.Name = window.Name;
                result.TotalSubElements = window.TotalSubElements;
                result.QuantityOfWindows = window.QuantityOfWindows;
                result.SalesOrderID = window.SalesOrderID;

                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteWindow(int id)
        {
            var result = await appDbContext.Windows
                .FirstOrDefaultAsync(e => e.ID == id);
            if (result != null)
            {
                appDbContext.Windows.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }
    }
}

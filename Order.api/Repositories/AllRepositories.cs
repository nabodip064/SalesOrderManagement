using Order.api.Context;
using Order.Models.Entity;

namespace Order.api.Repositories
{
    public class AllRepositories : IDisposable
    {
        private AppDBContext context;
        private GenericRepository<SalesOrder> salesOrderRepository;
        private GenericRepository<SubElement> subElementRepository;
        private GenericRepository<Window> windowRepository;
        public AllRepositories(AppDBContext context)
        {
            this.context = context;
        }

        public GenericRepository<SalesOrder> SalesOrderRepository
        {
            get
            {

                if (this.salesOrderRepository == null)
                {
                    this.salesOrderRepository = new GenericRepository<SalesOrder>(context);
                }
                return salesOrderRepository;
            }
        }

        public GenericRepository<SubElement> SubElementRepository
        {
            get
            {

                if (this.subElementRepository == null)
                {
                    this.subElementRepository = new GenericRepository<SubElement>(context);
                }
                return subElementRepository;
            }
        }

        public GenericRepository<Window> WindowRepository
        {
            get
            {

                if (this.windowRepository == null)
                {
                    this.windowRepository = new GenericRepository<Window>(context);
                }
                return windowRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

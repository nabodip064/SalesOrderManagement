using Microsoft.EntityFrameworkCore;
using Order.Models.Entity;

namespace Order.api.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DbSet<Window> Windows { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SalesOrder>()
        //        .HasData(
        //    new SalesOrder() {
        //        Name = "New York Building 1",
        //        State = "NY" },

        //    new SalesOrder() {
        //    Name = "California Hotel AJK",
        //    State = "CA"}
        //    );

        //    modelBuilder.Entity<SubElement>()
        //        .HasData(
        //        new SubElement()
        //        {
        //            Element = 1,
        //            Type = "Doors",
        //            Width = 1200,
        //            Height = 1850,
        //            WindowId = 1
        //        },
        //        new SubElement()
        //        {
        //            Element = 2,
        //            Type = "Window",
        //            Width = 800,
        //            Height = 1850,
        //            WindowId = 1
        //        },
        //        new SubElement()
        //        {
        //            Element = 3,
        //            Type = "Window",
        //            Width = 700,
        //            Height = 1850,
        //            WindowId = 1
        //        },
        //        new SubElement()
        //        {
        //            Element = 1,
        //            Type = "Window",
        //            Width = 1500,
        //            Height = 2000,
        //            WindowId = 2
        //        },
        //        new SubElement()
        //        {
        //            Element = 1,
        //            Type = "Doors",
        //            Width = 1400,
        //            Height = 2000,
        //            WindowId = 3
        //        },
        //        new SubElement()
        //        {
        //            Element = 2,
        //            Type = "Window",
        //            Width = 600,
        //            Height = 2200,
        //            WindowId = 3
        //        },
        //        new SubElement()
        //        {
        //            Element = 1,
        //            Type = "Window",
        //            Width = 1500,
        //            Height = 2000,
        //            WindowId = 4
        //        });

        //    modelBuilder.Entity<Window>()
        //        .HasData(
        //        new Window()
        //        {
        //            Name = "A51",
        //            QuantityOfWindows = 4,
        //            TotalSubElements = 3,
        //            SalesOrderID = 1
        //        },
        //        new Window()
        //        {
        //            Name = "C Zone 5",
        //            QuantityOfWindows = 2,
        //            TotalSubElements = 1,
        //            SalesOrderID = 1
        //        },
        //        new Window()
        //        {
        //            Name = "GLB",
        //            QuantityOfWindows = 2,
        //            TotalSubElements = 3,
        //            SalesOrderID = 2
        //        },
        //        new Window()
        //        {
        //            Name = "OHF",
        //            QuantityOfWindows = 10,
        //            TotalSubElements = 2,
        //            SalesOrderID = 2
        //        });

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

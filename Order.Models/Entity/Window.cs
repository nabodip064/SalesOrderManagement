using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Models.Entity
{
    public class Window
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        [ForeignKey("SalesOrderID")]
        public SalesOrder? SalesOrderItem { get; set; }
        public int? SalesOrderID { get; set; }
    }
}

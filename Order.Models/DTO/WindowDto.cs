using Order.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Models.DTO
{
    public class WindowDto
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public int QuantityOfWindows { get; set; }
        public int? SalesOrderID { get; set; }
        public int TotalSubElements { get; set; }
    }
}

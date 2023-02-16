using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Models.DTO
{
    public class SalesOrderDto
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MinLength(2)]
        public string State { get; set; } = string.Empty;
    }
}

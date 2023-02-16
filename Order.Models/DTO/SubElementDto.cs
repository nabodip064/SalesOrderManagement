using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Models.DTO
{
    public class SubElementDto
    {
        public int ID { get; set; }
        [Required]
        public int Element { get; set; }
        [Required]
        [MinLength(3)]
        public string Type { get; set; } = string.Empty;
        [Required]
        public int Width { get; set; }
        [Required]
        public int Height { get; set; }
        public int? WindowID { get; set; }
    }
}

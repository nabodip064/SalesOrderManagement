using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Models.Entity
{
    public class SubElement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Element { get; set; }
        public string Type { get; set; } = string.Empty;
        public int Width { get; set; }
        public int Height { get; set; }
        [ForeignKey("WindowID")]
        public Window? WindowItem { get; set; }
        public int? WindowID { get; set; }
    }
}

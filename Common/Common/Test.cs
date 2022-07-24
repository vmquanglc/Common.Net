using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Test : BaseEntity
    {
        [Required]
        public string MyProperty1 { get; set; }
        [Required]
        public string x { get; set; }
        [Key]
        [Column]
        [Required]
        [DisplayName("Quang")]
        public int? MyProperty3 { get; set; }
    };
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    [Table("API_Key_Management")]
    public class apikeycontrol
    {
        [Key]
        [Column("EKey")]
        public string ekey { get; set; }

        [Column("SMSCount")]
        public int smscounter { get; set; }
    }
}

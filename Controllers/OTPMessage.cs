using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    [Table("OTPMessages")]
    public class OTPMessage
    {
        [Column("Message")]
        public string Message { get; set; }

        [Column("Sender")]
        public string Sender { get; set; }

        [Key]
        [Column("Receiver")]
        public string Receiver { get; set; }

        [Column("API Key")]
        public string api { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("Email")]
        public string emailid{ get; set; }

        [Column("Phone Number")]
        public string phonenumber { get; set; }

        [Column("API Key")]
        public string api { get; set; }

        [Column("Limit")]
        public int Limit { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public interface iapikeycontrol
    {
        apikeycontrol Add(apikeycontrol control);

        apikeycontrol Update(apikeycontrol control);

        apikeycontrol Delete(string email);

        IEnumerable<apikeycontrol> allusage();
        int smscount(string email);

        apikeycontrol reset(string email);

    }
}

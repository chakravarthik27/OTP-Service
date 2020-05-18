using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public interface iotpmessage
    {
        IEnumerable<OTPMessage> GetOTPMessages();

        OTPMessage Add(OTPMessage message);

        OTPMessage Update(OTPMessage message);

        OTPMessage Delete(String receiver);

        OTPMessage GetMessage(String receiver);
    }
}

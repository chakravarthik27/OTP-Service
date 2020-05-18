using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public class sqlotpmessage : iotpmessage
    {
        private readonly AppDbContext context;


        public sqlotpmessage(AppDbContext context)
        {
            this.context = context;
        }
        public OTPMessage Add(OTPMessage message)
        {
            context.GetOTPMessages.Add(message);
            var e = context.getAPI.First(a => a.ekey == message.api);
            e.smscounter = e.smscounter + 1;
            context.SaveChanges();
            return message;
        }

        public OTPMessage Delete(string receiver)
        {
            OTPMessage message = context.GetOTPMessages.FirstOrDefault(e => e.Receiver == receiver);
            if(message != null)
            {
                context.Remove(message);
                context.SaveChanges();
            }
            return message;
        }

        public OTPMessage GetMessage(string receiver)
        {
            return context.GetOTPMessages.FirstOrDefault(e => e.Receiver == receiver);

        }

        public IEnumerable<OTPMessage> GetOTPMessages()
        {
            return context.GetOTPMessages.ToList();
        }

        public OTPMessage Update(OTPMessage content)
        {
            var content2 = context.GetOTPMessages.Attach(content);
           // var content3 = context.getAPI.Attach(control);
            content2.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           // content3.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return content;

        }
    }
}

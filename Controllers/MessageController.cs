using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedOTPService.Controllers
{
    [Route("messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly iotpmessage _message;

        private readonly iuser _iuser;

        private readonly iapikeycontrol _control;

        
        public MessageController(iotpmessage message, iuser user, iapikeycontrol control)
        {
            this._iuser = user;
            this._control = control;
            this._message = message;
        }

        // GET: api/Message
        [HttpGet]
        public IEnumerable<OTPMessage> Get()
        {
            return _message.GetOTPMessages();
        }

        // GET: api/Message/5
        [HttpGet("save")]
        public ActionResult<string> Get(string message, string sender, string receiver, string email)
        {
            try
            {
                User lm = _iuser.Userdetails(email);
                int g = lm.Limit;
                Console.WriteLine(g);
                int limit = _control.smscount(email);
                Console.WriteLine(limit);

                if (g != limit)
                {
                    OTPMessage otpmessage = new OTPMessage { Message = message, Sender = sender, api = email, Receiver = receiver };
                    _message.Add(otpmessage);

                    return "Message was added Successfully";
                }
                else
                {
                    return "Your limit was reached... Please renew";
                }



            }
            catch (Exception e)
            {
                return e.ToString();
            }
            
        }

        [HttpGet("delete/{receiver}")]
        public ActionResult<OTPMessage> delete(string receiver)
        {
            return _message.Delete(receiver);
        }

        [HttpGet("update")]
        public ActionResult<string> update(string message, string receiver, string sender, string email)
        {
            string em = email;
            int g = _iuser.Userdetails(email).Limit;
            int limit = _control.smscount(email);

            if (g != limit)
            {
                OTPMessage otpmessage = new OTPMessage { Message = message, Sender = sender, api = email, Receiver = receiver };
                apikeycontrol control = new apikeycontrol { ekey = em, smscounter = limit + 1 };
               // _control.Update(control);
                _message.Update(otpmessage);
                return "Message was updated Successfully";
            }
            else
            {
                return "Your limit was reached... Please renew";
            }



        }

        [HttpGet("{receiver}")]
        public ActionResult<OTPMessage> getmess(string receiver)
        {
            OTPMessage otp = null;
            do
            {
                otp = getmessage(receiver);
                if(otp != null)
                {
                    deletemsg(receiver, 5000);
                    return otp;
                   
                }

            } while (true);
        }

        public OTPMessage getmessage(string receiver)
        {
            return _message.GetMessage(receiver);
        }

        public void deletemsg(string receiver, int delay)
        {
            int i = 0;
            do
            {
                if( i == delay)
                {
                    _message.Delete(receiver);
                    break;

                }
                Console.WriteLine("number" + i.ToString());
                i++;
               

            } while (i<=delay);
        }
    }
}

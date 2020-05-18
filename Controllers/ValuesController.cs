using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Scheduler.Models;

namespace AdvancedOTPService.Controllers
{
    [Route("/")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        private readonly iuser _iuser;

        private readonly iapikeycontrol _control;
        public ValuesController(iuser user, iapikeycontrol control)
        {
            this._control = control;
            this._iuser = user;
        }



        // GET api/values
       
        [HttpGet]
        public ActionResult<String> Get()
        {

            return "Sorry...! unable to load.." ;//_iuser.getallUsers().ToList();
        }
    
        // ----------user activities-------------

        [HttpGet("Register")]
        public ActionResult<string> addUser(string email, string pnumber, int limit)
        {
            try  {
                
                string apikey = apigen(email + "/" + pnumber);
                User user = new User { emailid = email, phonenumber = pnumber, api = apikey, Limit = limit };
                apikeycontrol c = new apikeycontrol { ekey = email, smscounter = 0 };
                _control.Add(c);
                _iuser.Add(user);

                return "User Registration was Sucessfully Done";
            }catch(Exception e)
            {
                return "error" + e.ToString();

            }
          
        }

        
        [HttpGet("getuser")]

        public User getuser(string email)
        {
            return _iuser.Userdetails(email);
        }

        [HttpGet("users")]

        public IEnumerable<User> getuser()
        {
            return _iuser.getallUsers();
        }

        [HttpGet("deleteuser")]
        public User deluser(string email)
        {
            _control.Delete(email);
            return _iuser.Delete(email);

        }

        [HttpGet("analytics")]

        public IEnumerable<apikeycontrol> usage()
        {
            return _control.allusage();
        }

        [HttpGet("analytics/{email}")]
        public int delapi(string email)
        {
            return _control.smscount(email);
        }

        

        [HttpGet("analytics/reset/{email}")]
        public apikeycontrol restapi(string email)
        {
           return _control.reset(email);
        }

        public String apigen(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Merge all bytes into a string of bytes  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}

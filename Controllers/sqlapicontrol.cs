using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public class sqlapicontrol : iapikeycontrol
    {
        private readonly AppDbContext _apicontext;

        public sqlapicontrol(AppDbContext context)
        {
            this._apicontext = context;
        }
        public apikeycontrol Add(apikeycontrol control)
        {
            _apicontext.getAPI.Add(control);
            _apicontext.SaveChanges();
            return control;
        }

        public apikeycontrol Delete(string email)
        {
            apikeycontrol control = _apicontext.getAPI.FirstOrDefault(e => e.ekey == email);
            if(control != null)
            {
                _apicontext.Remove(control);
                _apicontext.SaveChanges();
            }

            return control;
        }

        public IEnumerable<apikeycontrol> allusage()
        {
            return _apicontext.getAPI.ToList();
        }

        public int smscount(string email)
        {
            apikeycontrol control = _apicontext.getAPI.First(e => e.ekey == email);
            return control.smscounter;
        }
        public apikeycontrol reset(string email)
        {
            apikeycontrol control = _apicontext.getAPI.First(a => a.ekey == email);
            control.smscounter = 0;
            _apicontext.SaveChanges();
            return control;
        }
        public apikeycontrol Update(apikeycontrol control)
        {
            var content1 = _apicontext.getAPI.Attach(control);
            content1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _apicontext.SaveChanges();
            return control;
        }
    }
}

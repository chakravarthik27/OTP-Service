using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public class sqluser : iuser
    {
        private readonly AppDbContext context;
        public sqluser(AppDbContext context)
        {
            this.context = context;
        }
        public User Add(User user)
        {
            context.GetUser.Add(user);
            context.SaveChanges();
            return user;

        }


        public User Delete(string pnum)
        {
            User user = context.GetUser.FirstOrDefault(e => e.emailid == pnum);
            if(user != null)
            {
                context.Remove(user);
                context.SaveChanges();
            }

            return user;
        }

        public IEnumerable<User> getallUsers()
        {
            return context.GetUser.ToList();
        }


        public User Update(User user)
        {

            var content1 = context.GetUser.Attach(user);
            content1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return user;
        }

        public User Userdetails(string email)
        {
            return context.GetUser.FirstOrDefault(e => e.emailid == email); 
        }
    }
}

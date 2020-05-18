using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedOTPService.Controllers
{
    public interface iuser
    {
        IEnumerable<User> getallUsers();

        User Userdetails(String email);
       
        User Add(User user);

        User Delete(String email);

        User Update(User user);
    }
}

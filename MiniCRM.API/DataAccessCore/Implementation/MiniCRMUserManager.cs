using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessCore.Implementation
{
    public class MiniCRMUserManager : UserManager<IdentityUser>
    {
        public MiniCRMUserManager() : base(new MiniCRMUserStore())
        {
        }
    }
}

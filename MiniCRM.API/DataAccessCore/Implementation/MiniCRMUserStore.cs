using DataAccessCore.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccessCore.Implementation
{

    public class MiniCRMUserStore : UserStore<IdentityUser>
    {
        public MiniCRMUserStore() : base(new MiniCRMModel())
        {
        }
    }
}

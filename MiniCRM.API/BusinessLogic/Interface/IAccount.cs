using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;
using DataAccessCore.Models;

namespace BusinessLogic.Interface
{
    public interface IAccount
    {
        IEnumerable<AccountGetModel> AccountGet();
        int AccountInsert(Account emp);
        int AccountUpdate(EditAccountBindingModel model, Account user);
        // int AdminDelete(int id);
    }
}

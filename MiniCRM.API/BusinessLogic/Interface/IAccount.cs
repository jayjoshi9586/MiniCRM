using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;
namespace BusinessLogic.Interface
{
    public interface IAccount
    {
        IEnumerable<Account> AccountGet();
        int AccountInsert(Account emp);
        int AccountUpdate(EditAccountBindingModel model, Account user);
        // int AdminDelete(int id);
    }
}

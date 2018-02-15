using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;
namespace BusinessLogic.Interface
{
    public interface IAdmin
    {
        IEnumerable<Admin> AdminGet();
        int AdminInsert(Admin emp);
        int AdminUpdate(EditProfileBindingModel model, Admin emp);
        //int AdminDelete(int id);
    }
}

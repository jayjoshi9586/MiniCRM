using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;
using DataAccessCore.Models;

namespace BusinessLogic.Interface
{
    public interface ICategory
    {
        IEnumerable<CategoryResponseModel> CategoryGet();
        int CategoryInsert(Category emp);
        int CategoryUpdate(CategoryModel emp);
        //int AdminDelete(int id);
    }
}

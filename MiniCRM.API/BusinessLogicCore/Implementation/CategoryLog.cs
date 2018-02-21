
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using DataAccessCore.Entities;
using DataAccessCore.Implementation;
using DataAccessCore.Models;

namespace BusinessLogicCore.Implementation
{
    public class CategoryLog : ICategory
    {
        private Binding binding = new Binding();
        private List<Category> lstEmp = new List<Category>();
        private List<CategoryResponseModel> lstEmps = new List<CategoryResponseModel>();
        private Category objEmp = new Category();
        private CategoryResponseModel objEmps = new CategoryResponseModel();

        public IEnumerable<CategoryResponseModel> CategoryGet()
        {
            lstEmp = binding.GetCategoryRepository.Get().ToList();

            return lstEmps;
        }

        public CategoryResponseModel CategoryGet(int id)
        {
            objEmp = binding.GetCategoryRepository.GetByID(id);
            return objEmps;
        }
        public CategoryResponseModel GetByCategoryname(string Categoryname)
        {
            objEmp = binding.GetCategoryRepository.GetByCategoryname(Categoryname);
            return objEmps;
        }

        //public int DeActivateBeacon(String beaconname)
        //{
        //    Category beacon = GetByCategoryname(beaconname);
        //    beacon.IsDeleted = true;
        //    int result = this.binding.Save();

        //    if (result > 0)
        //    {
        //        result = 1;
        //        return result;
        //    }
        //    else
        //    {
        //        result = 0;
        //        return result;
        //    }
        //}

        //public int ActivateBeacon(String beaconname)
        //{
        //    Beacon beacon = GetByBeaconname(beaconname);
        //    beacon.IsDeleted = false;
        //    int result = this.binding.Save();

        //    if (result > 0)
        //    {
        //        result = 1;
        //        return result;
        //    }
        //    else
        //    {
        //        result = 0;
        //        return result;
        //    }

        //}

        public int CategoryUpdate(CategoryModel model)
        {
            Category category = new Category(CategoryGet(model.Category_id));
            //Beacon beacon = new Beacon(beacon1);
            if (category != null)
            {
                category.Category_name = model.Category_name;
            }
            this.binding.GetCategoryRepository.Attach(category);
            int result = this.binding.Save();

            if (result > 0)
            {
                result = 1;
                return result;
            }
            else
            {
                result = 0;
                return result;
            }
        }

        public int CategoryInsert(Category emp)
        {
            this.binding.GetCategoryRepository.Insert(emp);
            int inserData = this.binding.Save();

            if (inserData > 0)
            {
                inserData = 1;
                return inserData;
            }
            else
            {
                inserData = 0;
                return inserData;
            }
        }
    }
}

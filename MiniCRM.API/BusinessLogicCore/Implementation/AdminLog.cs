
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interface;
using DataAccessCore.Entities;
using DataAccessCore.Implementation;

namespace BusinessLogicCore.Implementation
{
    public class AdminLog : IAdmin
    {
        private Binding binding = new Binding();
        private List<Admin> lstEmp = new List<Admin>();
        private Admin objEmp = new Admin();

        public IEnumerable<Admin> AdminGet()
        {
            lstEmp = binding.GetAdminRepository.Get().ToList();

            return lstEmp;
        }

        public Admin AdminGet(int id)
        {
            objEmp = binding.GetAdminRepository.GetByID(id);
            return objEmp;
        }
        public Admin GetByUsername(string Username)
        {
            objEmp = binding.GetAdminRepository.GetByUsername(Username);
            return objEmp;
        }

        public int ValidateUser(LoginTestBindingModel model)
        {
            objEmp = GetByUsername(model.Username);
            if (objEmp==null)
            {
                return 0;
            }
            else
            {
                int validate = binding.GetAdminRepository.ValidateUser(objEmp,model);
                return validate;
            }
        }

        public Admin GetByEmail(string Email)
        {
            objEmp = binding.GetAdminRepository.GetByEmail(Email);
            return objEmp;
        }

        public int AdminUpdate(EditProfileBindingModel model, Admin user)
        {

            //objEmp = binding.GetAdminRepository.GetByID(emp.Admin_id);     
          
            if (user != null)
            {
                user.Admin_firstname = model.Admin_firstname;
                user.Admin_lastname = model.Admin_lastname;
                user.Admin_gender = model.Admin_gender;
                user.Admin_dob = model.Admin_dob;
                user.Admin_aadhar_id = model.Admin_aadhar_id;
                user.Admin_pan_card = model.Admin_pan_card;
                user.Admin_gst_id = model.Admin_gst_id;
            }
            this.binding.GetAdminRepository.Attach(user);
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

        public int AdminDelete(int id)
        {
            var objEmp = this.binding.GetAdminRepository.GetByID(id);
            this.binding.GetAdminRepository.Delete(objEmp);
            int deleteData = this.binding.Save();
            if (deleteData > 0)
            {
                deleteData = 1;
                return deleteData;
            }
            else
            {
                deleteData = 0;
                return deleteData;
            }
        }

        public int AdminInsert(Admin emp)
        {
            this.binding.GetAdminRepository.Insert(emp);
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

        //    public virtual Admin GetUser(string userName, string password)
        //{
        //    MiniCRMModel db = new MiniCRMModel();
        //    Admin admin = db.Admins.Find(userName);
        //    if (admin.Admin_pwd == password)
        //    {
        //        return admin;
        //    }
        //    // IQueryable<Admin> admin1 = db.Admins.Where(x=>x.Admin_username == userName);
        //    //Admin admin;
        //    return null;
        //}
    }

        public int AdminInsert()
        {
            throw new NotImplementedException();
        }
    }
}

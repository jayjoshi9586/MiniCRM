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
    public class AccountLog : IAccount
    {
        private AccountBinding binding = new AccountBinding();
        private List<Account> lstEmp = new List<Account>();
        private Account objEmp = new Account();

        public IEnumerable<Account> AccountGet()
        {
            lstEmp = binding.GetAccountRepository.Get().ToList();

            return lstEmp;
        }

        public Account AccountGet(int id)
        {
            objEmp = binding.GetAccountRepository.GetByID(id);
            return objEmp;
        }

        public int AccountUpdate(Account user)
        {

            //objEmp = binding.GetAdminRepository.GetByID(emp.Admin_id);

            //if (user != null)
            //{
            //    user.Admin_firstname = model.Admin_firstname;
            //    user.Admin_lastname = model.Admin_lastname;
            //    user.Admin_gender = model.Admin_gender;
            //    user.Admin_dob = model.Admin_dob;
            //    user.Admin_aadhar_id = model.Admin_aadhar_id;
            //    user.Admin_pan_card = model.Admin_pan_card;
            //    user.Admin_gst_id = model.Admin_gst_id;
            //}
            this.binding.GetAccountRepository.Attach(user);
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

        //public int AdminDelete(int id)
        //{
        //    var objEmp = this.binding.GetAdminRepository.GetByID(id);
        //    this.binding.GetAdminRepository.Delete(objEmp);
        //    int deleteData = this.binding.Save();
        //    if (deleteData > 0)
        //    {
        //        deleteData = 1;
        //        return deleteData;
        //    }
        //    else
        //    {
        //        deleteData = 0;
        //        return deleteData;
        //    }
        //}

        public int AccountInsert(CreateAccountBindingModel emp)
        {
            this.binding.GetAccountRepository.Insert(emp);
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

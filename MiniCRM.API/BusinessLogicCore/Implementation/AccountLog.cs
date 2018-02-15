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
        private Binding binding = new Binding();
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

        public int AccountUpdate(EditAccountBindingModel model, Account user)
        {
            if (user != null)
            {
                user.Account_id = model.Account_id;
                user.Account_name = model.Account_name;
                user.Account_global_email = model.Account_global_email;
                user.Account_brand_logo = model.Account_brand_logo;
               
            }
            this.binding.GetAccountRepository.Attach(objEmp);
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
        public int AdminUpdate(EditProfileBindingModel model, Admin user)
        {
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
        public Account GetByAccountname(string Accountname)
        {
            objEmp = binding.GetAccountRepository.GetByAccountname(Accountname);
            return objEmp;
        }

        //public int ValidateUser(LoginTestBindingModel model)
        //{
        //    objEmp = GetByUsername(model.Username);
        //    if (objEmp == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        int validate = binding.GetAccountRepository.ValidateUser(objEmp, model);
        //        return validate;
        //    }
        //}

        public int DeActivateAccount(String Accountname)
        {
            Account admin = GetByAccountname(Accountname);
            admin.IsDeleted = true;
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

        public int ActivateAccount(String username)
        {
            Account admin = GetByAccountname(username);
            admin.IsDeleted = false;
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

        public Account GetByEmail(string Email)
        {
            objEmp = binding.GetAccountRepository.GetByEmail(Email);
            return objEmp;
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

        public int AccountInsert(Account emp)
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

        public int BranchInsert(Accounts_branch emp)
        {
            this.binding.GetBranchRepository.Insert(emp);
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

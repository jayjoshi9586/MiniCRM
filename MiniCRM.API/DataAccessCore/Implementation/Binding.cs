using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessCore.Entities;

namespace DataAccessCore.Implementation
{
    public class Binding //: IDisposable
    {
        private string errorMessage = string.Empty;

        /// <summary>
        /// Defines condition for disposing object
        /// </summary>
        private bool disposed = false;

        private DataAccess<Admin> AdminInfoRepository;
        private DataAccess<Account> AccountInfoRepository;// = new DataAccess<Account>(MiniCRMModel);
        private DataAccess<Accounts_branch> BranchInfoRepository;// = new DataAccess<Account>(MiniCRMModel);

        /// <summary>
        /// Initializes a new instance of the MyModel class
        /// </summary>
        //private ApplicationDbContext objMyModel = new ApplicationDbContext();
        private MiniCRMModel objMyModel = new MiniCRMModel();


        /// <summary>
        /// Gets the get employee repository.
        /// </summary>
        /// <value>
        /// The get employee repository.
        /// </value>
        public DataAccess<Admin> GetAdminRepository
        {
            get
            {
                if (this.AdminInfoRepository == null)
                {
                    this.AdminInfoRepository = new DataAccess<Admin>(this.objMyModel);
                }

                return this.AdminInfoRepository;
            }
        }

        public DataAccess<Account> GetAccountRepository
        {
            get
            {
                if (this.AccountInfoRepository == null)
                {
                    this.AccountInfoRepository = new DataAccess<Account>(this.objMyModel);
                }

                return this.AccountInfoRepository;
            }
        }

        public DataAccess<Accounts_branch> GetBranchRepository
        {
            get
            {
                if (this.BranchInfoRepository == null)
                {
                    this.BranchInfoRepository = new DataAccess<Accounts_branch>(this.objMyModel);
                }

                return this.BranchInfoRepository;
            }
        }

        /// <summary>
        /// This Method will commit the changes to database for the permanent save
        /// </summary>
        /// <returns>
        /// affected rows
        /// </returns>
        public int Save()
        {
            return objMyModel.SaveChanges();
        }
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// This method will dispose the context class object after the uses of that object
        /// </summary>
        /// <param name="disposing">parameter true or false for disposing database object</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.objMyModel.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}

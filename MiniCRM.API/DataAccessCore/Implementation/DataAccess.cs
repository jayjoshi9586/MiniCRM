using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interface;
using DataAccessCore.Entities;

namespace DataAccessCore.Implementation
{
    public class DataAccess<TEntity> : IDataAccess<TEntity> where TEntity : class
    {
        /// <summary>
        /// The context
        /// </summary>
        //internal MiniCRMModel context;
        //internal ApplicationDbContext context;
        internal MiniCRMModel context;
        private IDataAccess<TEntity> _access;

        /// <summary>
        /// The database set
        /// </summary>
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Initializes the new instance of AdminModel Model
        /// </summary>
        /// <param name="context">context object</param>
        /// 
        public DataAccess(MiniCRMModel context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public DataAccess(IDataAccess<TEntity> access)
        {
            this._access = access;
        }

        /// <summary>
        /// Gets all data
        /// </summary>
        /// <returns>collection of specified class.</returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> query = this.dbSet;
            return query.ToList();
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name ="id"> The identifier.</param>
        /// <returns> object </returns>
        public virtual TEntity GetByID(int id)
        {
            return this.dbSet.Find(id);
        }

        public virtual Admin GetByUsername(string Username)
        {
            //var dbEntry = context.Admins.FirstOrDefault(acc => acc.Admin_username == Username);
            //return this.dbSet.Find(Username);
            
            return context.Admins.FirstOrDefault(acc => acc.Admin_username == Username);
        }
        public virtual TEntity GetByName(string Username)
        {
            //var dbEntry = context.Admins.FirstOrDefault(acc => acc.Admin_username == Username);
            //return this.dbSet.Find(Username);
            return this.dbSet.Find(Username);

            //return context.Admins.FirstOrDefault(acc => acc.Admin_username == Username);
        }

        public virtual Account GetByAccountname(string Accountname)
        {
            //var dbEntry = context.Admins.FirstOrDefault(acc => acc.Admin_username == Username);
            //return this.dbSet.Find(Username);

            return context.Accounts.FirstOrDefault(acc => acc.Account_name == Accountname);
        }

        public virtual TEntity GetByEmail(string email)
        {
            
            return this.dbSet.Find(email);
            //context.Admins.FirstOrDefault(acc => acc.Admin_email == email);
        }

        public virtual int ValidateUser(Admin admin,LoginTestBindingModel credentials)
        {
           //Admin admin1=GetByUsername(admin.Admin_username);            
            if (credentials.Password==admin.Admin_pwd)
            {
                return 1;
            }
            return 0;

        }
        /// <summary>
        /// Insert data
        /// </summary>
        /// <param name="entity">object for insertion.</param>
        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        //public virtual void AdminRegister(RegisterBindingModel model)
        //{
        //    this.dbSet.Add();
        //}
        /// <summary>
        ///  Delete data by id
        /// </summary>
        /// <param name="id">id</param>
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name ="entityToDelete">entity To Delete.</param>
        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);
        }

        /// <summary>
        /// Attach data.
        /// </summary>
        /// <param name="entityToUpdate">entity To Update.</param>
        public virtual void Attach(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

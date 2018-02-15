namespace DataAccessCore.Migrations
{
    using DataAccessCore.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessCore.Entities.MiniCRMModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessCore.Entities.MiniCRMModel context)
        {
            context.Admins.AddOrUpdate(new Admin
            {
                Admin_id = 1,
                Admin_username = "jayjoshi",
                Admin_email = "jay.joshi.det@gmail.com",
                Admin_contact_no = 9898989898,
                Admin_firstname = "Jay",
                Admin_lastname = "Joshi",
                Admin_pwd = "Det@123$"
            });
        }
    }
}

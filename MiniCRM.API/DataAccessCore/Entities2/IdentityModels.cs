using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace DataAccessCore.Entities2
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]        
        public int Admin_type_id { get; set; }
        public string Admin_firstname { get; set; }
        public string Admin_lastname { get; set; }
        public string Admin_gender { get; set; }
        public DateTime? Admin_dob { get; set; }
        public decimal? Admin_aadhar_id { get; set; }
        public decimal? Admin_pan_card { get; set; }
        public decimal? Admin_gst_id { get; set; }
        public string Admin_status { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {

        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.LoginProvider);
        }

    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {

        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.RoleId);
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MiniCRM", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accounts_branch> Accounts_branch { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminType> AdminTypes { get; set; }
        public virtual DbSet<Beacon> Beacons { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Timing_Table> Timing_Table { get; set; }
        public virtual DbSet<Account_Admin> Account_Admin { get; set; }
        public virtual DbSet<Account_Beacon> Account_Beacon { get; set; }
        public virtual DbSet<Account_Branches> Account_Branches { get; set; }
        public virtual DbSet<Account_Category> Account_Category { get; set; }
        public virtual DbSet<Module> Modules { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
            //modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");


            modelBuilder.Entity<Account>()
               .Property(e => e.Account_name)
               .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_global_email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Account_Admin)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Account_Beacon)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Account_Branches)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Account_Category)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Accounts_branch)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Accounts_branch>()
                .Property(e => e.Account_address)
                .IsUnicode(false);

            modelBuilder.Entity<Accounts_branch>()
                .Property(e => e.Account_phone)
                .HasPrecision(13, 0);

            modelBuilder.Entity<Accounts_branch>()
                .Property(e => e.Account_email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_gender)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_contact_no)
                .HasPrecision(13, 0);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_email)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_pwd)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_aadhar_id)
                .HasPrecision(13, 0);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_pan_card)
                .HasPrecision(13, 0);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_gst_id)
                .HasPrecision(13, 0);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_status)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.Admin_username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .HasMany(e => e.Account_Admin)
                .WithRequired(e => e.Admin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdminType>()
                .Property(e => e.Admin_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<AdminType>()
                .HasMany(e => e.Admins)
                .WithRequired(e => e.AdminType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdminType>()
                .HasMany(e => e.Modules)
                .WithRequired(e => e.AdminType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beacon>()
                .Property(e => e.Beacon_title)
                .IsUnicode(false);

            modelBuilder.Entity<Beacon>()
                .Property(e => e.Beacon_uuid)
                .IsUnicode(false);

            modelBuilder.Entity<Beacon>()
                .Property(e => e.Beacon_trigger_proximity)
                .IsUnicode(false);

            modelBuilder.Entity<Beacon>()
                .Property(e => e.Beacon_message)
                .IsUnicode(false);

            modelBuilder.Entity<Beacon>()
                .HasMany(e => e.Account_Beacon)
                .WithRequired(e => e.Beacon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Account_Category)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Right>()
                .Property(e => e.Right_name)
                .IsUnicode(false);

            modelBuilder.Entity<Right>()
                .Property(e => e.Right_delete)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Right>()
                .Property(e => e.Right_update)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Right>()
                .Property(e => e.Right_view)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Right>()
                .Property(e => e.Right_add)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Right>()
                .HasMany(e => e.Modules)
                .WithRequired(e => e.Right)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Right>()
                .HasOptional(e => e.Rights1)
                .WithRequired(e => e.Right1);

            modelBuilder.Entity<Timing_Table>()
                .Property(e => e.Timing_day)
                .IsUnicode(false);

            modelBuilder.Entity<Timing_Table>()
                .HasMany(e => e.Accounts_branch)
                .WithRequired(e => e.Timing_Table)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Module>()
                .Property(e => e.Module_name)
                .IsUnicode(false);
        }
        //// public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        // public virtual DbSet<Account> Accounts { get; set; }
        // public virtual DbSet<Accounts_branch> Accounts_branch { get; set; }
        // public virtual DbSet<Admin> Admins { get; set; }
        // public virtual DbSet<AdminType> AdminTypes { get; set; }
        // public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        // public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        // public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        // public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        // public virtual DbSet<Beacon> Beacons { get; set; }
        // public virtual DbSet<Category> Categories { get; set; }
        // public virtual DbSet<Right> Rights { get; set; }
        // public virtual DbSet<Timing_Table> Timing_Table { get; set; }
        // public virtual DbSet<Account_Branches> Account_Branches { get; set; }
        // public virtual DbSet<Module> Modules { get; set; }

        // protected override void OnModelCreating(DbModelBuilder modelBuilder)
        // {

        //     modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
        //     modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

        //     modelBuilder.Entity<Account>()
        //         .Property(e => e.Account_name)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Account>()
        //         .Property(e => e.Account_global_email)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Account>()
        //         .HasMany(e => e.Account_Branches)
        //         .WithRequired(e => e.Account)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<Account>()
        //         .HasMany(e => e.Accounts_branch)
        //         .WithRequired(e => e.Account)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<Account>()
        //         .HasMany(e => e.Admins)
        //         .WithMany(e => e.Accounts)
        //         .Map(m => m.ToTable("Account_Admin").MapLeftKey("Account_id").MapRightKey("Admin_id"));

        //     modelBuilder.Entity<Account>()
        //         .HasMany(e => e.Beacons)
        //         .WithMany(e => e.Accounts)
        //         .Map(m => m.ToTable("Account_Beacon").MapLeftKey("Account_id").MapRightKey("Beacon_id"));

        //     modelBuilder.Entity<Account>()
        //         .HasMany(e => e.Categories)
        //         .WithMany(e => e.Accounts)
        //         .Map(m => m.ToTable("Account_Category").MapLeftKey("Account_id").MapRightKey("Category_id"));

        //     modelBuilder.Entity<Accounts_branch>()
        //         .Property(e => e.Account_address)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Accounts_branch>()
        //         .Property(e => e.Account_phone)
        //         .HasPrecision(13, 0);

        //     modelBuilder.Entity<Accounts_branch>()
        //         .Property(e => e.Account_email)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_firstname)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_lastname)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_gender)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_contact_no)
        //         .HasPrecision(13, 0);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_email)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_pwd)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_aadhar_id)
        //         .HasPrecision(13, 0);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_pan_card)
        //         .HasPrecision(13, 0);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_gst_id)
        //         .HasPrecision(13, 0);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_status)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Admin>()
        //         .Property(e => e.Admin_username)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<AdminType>()
        //         .Property(e => e.Admin_type_name)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<AdminType>()
        //         .HasMany(e => e.Admins)
        //         .WithRequired(e => e.AdminType)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<AdminType>()
        //         .HasMany(e => e.Modules)
        //         .WithRequired(e => e.AdminType)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<AspNetRole>()
        //         .HasMany(e => e.AspNetUsers)
        //         .WithMany(e => e.AspNetRoles)
        //         .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

        //     modelBuilder.Entity<AspNetUser>()
        //         .HasMany(e => e.AspNetUserClaims)
        //         .WithRequired(e => e.AspNetUser)
        //         .HasForeignKey(e => e.UserId);

        //     modelBuilder.Entity<AspNetUser>()
        //         .HasMany(e => e.AspNetUserLogins)
        //         .WithRequired(e => e.AspNetUser)
        //         .HasForeignKey(e => e.UserId);

        //     modelBuilder.Entity<Beacon>()
        //         .Property(e => e.Beacon_title)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Beacon>()
        //         .Property(e => e.Beacon_uuid)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Beacon>()
        //         .Property(e => e.Beacon_trigger_proximity)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Beacon>()
        //         .Property(e => e.Beacon_message)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Category>()
        //         .Property(e => e.Category_name)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .Property(e => e.Right_name)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .Property(e => e.Right_delete)
        //         .IsFixedLength()
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .Property(e => e.Right_update)
        //         .IsFixedLength()
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .Property(e => e.Right_view)
        //         .IsFixedLength()
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .Property(e => e.Right_add)
        //         .IsFixedLength()
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Right>()
        //         .HasMany(e => e.Modules)
        //         .WithRequired(e => e.Right)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<Right>()
        //         .HasOptional(e => e.Rights1)
        //         .WithRequired(e => e.Right1);

        //     modelBuilder.Entity<Timing_Table>()
        //         .Property(e => e.Timing_day)
        //         .IsUnicode(false);

        //     modelBuilder.Entity<Timing_Table>()
        //         .HasMany(e => e.Accounts_branch)
        //         .WithRequired(e => e.Timing_Table)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<Module>()
        //         .Property(e => e.Module_name)
        //         .IsUnicode(false);
        // }

    }
}

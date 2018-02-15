namespace DataAccessCore.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MiniCRMModel : DbContext
    {
        public MiniCRMModel()
            : base("name=MiniCRM")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Accounts_branch> Accounts_branch { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AdminType> AdminTypes { get; set; }
        public virtual DbSet<Beacon> Beacons { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Right> Rights { get; set; }
        public virtual DbSet<Timing_Table> Timing_Table { get; set; }
        public virtual DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Account_name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Account_global_email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Admins)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Account_Admin").MapLeftKey("Account_id").MapRightKey("Admin_id"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Beacons)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Account_Beacon").MapLeftKey("Account_id").MapRightKey("Beacon_id"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Accounts_branch)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Account_Branches").MapLeftKey("Account_id").MapRightKey("Account_branch_id"));

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Categories)
                .WithMany(e => e.Accounts)
                .Map(m => m.ToTable("Account_Category").MapLeftKey("Account_id").MapRightKey("Category_id"));

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

            modelBuilder.Entity<Category>()
                .Property(e => e.Category_name)
                .IsUnicode(false);

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
    }
}

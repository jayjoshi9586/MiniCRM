namespace DataAccessCore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeleted : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account_Branches",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        Account_branch_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_id, t.Account_branch_id })
                .ForeignKey("dbo.Accounts", t => t.Account_id)
                .Index(t => t.Account_id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        Account_name = c.String(unicode: false),
                        Account_brand_logo = c.Binary(storeType: "image"),
                        Account_global_email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Account_id);
            
            CreateTable(
                "dbo.Accounts_branch",
                c => new
                    {
                        Account_branch_id = c.Int(nullable: false),
                        Timing_id = c.Int(nullable: false),
                        Account_images = c.Binary(storeType: "image"),
                        Account_address = c.String(unicode: false),
                        Account_phone = c.Decimal(precision: 13, scale: 0, storeType: "numeric"),
                        Account_email = c.String(unicode: false),
                        Account_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Account_branch_id)
                .ForeignKey("dbo.Timing_Table", t => t.Timing_id)
                .ForeignKey("dbo.Accounts", t => t.Account_id)
                .Index(t => t.Timing_id)
                .Index(t => t.Account_id);
            
            CreateTable(
                "dbo.Timing_Table",
                c => new
                    {
                        Timing_id = c.Int(nullable: false),
                        Timing_day = c.String(maxLength: 10, unicode: false),
                        Timing_open = c.Time(precision: 7),
                        Timing_close = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.Timing_id);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Admin_id = c.Int(nullable: false),
                        Admin_firstname = c.String(maxLength: 50, unicode: false),
                        Admin_lastname = c.String(maxLength: 50, unicode: false),
                        Admin_gender = c.String(maxLength: 50, unicode: false),
                        Admin_contact_no = c.Decimal(precision: 13, scale: 0, storeType: "numeric"),
                        Admin_email = c.String(nullable: false, unicode: false),
                        Admin_type_id = c.Int(nullable: false),
                        Admin_pwd = c.String(nullable: false, maxLength: 88, unicode: false),
                        Admin_dob = c.DateTime(storeType: "date"),
                        Admin_aadhar_id = c.Decimal(precision: 13, scale: 0, storeType: "numeric"),
                        Admin_pan_card = c.Decimal(precision: 13, scale: 0, storeType: "numeric"),
                        Admin_gst_id = c.Decimal(precision: 13, scale: 0, storeType: "numeric"),
                        Admin_status = c.String(nullable: false, maxLength: 10, unicode: false),
                        Admin_username = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Admin_id)
                .ForeignKey("dbo.AdminTypes", t => t.Admin_type_id)
                .Index(t => t.Admin_type_id);
            
            CreateTable(
                "dbo.AdminTypes",
                c => new
                    {
                        Admin_type_id = c.Int(nullable: false),
                        Admin_type_name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Admin_type_id);
            
            CreateTable(
                "dbo.Module",
                c => new
                    {
                        Module_name = c.String(nullable: false, maxLength: 128, unicode: false),
                        Admin_type_id = c.Int(nullable: false),
                        Right_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Module_name, t.Admin_type_id, t.Right_id })
                .ForeignKey("dbo.Rights", t => t.Right_id)
                .ForeignKey("dbo.AdminTypes", t => t.Admin_type_id)
                .Index(t => t.Admin_type_id)
                .Index(t => t.Right_id);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        Right_id = c.Int(nullable: false),
                        Right_name = c.String(nullable: false, unicode: false),
                        Right_delete = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Right_update = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Right_view = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Right_add = c.String(maxLength: 1, fixedLength: true, unicode: false),
                        Right1_Right_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Right_id)
                .ForeignKey("dbo.Rights", t => t.Right1_Right_id)
                .Index(t => t.Right1_Right_id);
            
            CreateTable(
                "dbo.Beacon",
                c => new
                    {
                        Beacon_id = c.Int(nullable: false),
                        Beacon_title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Beacon_uuid = c.String(nullable: false, maxLength: 50, unicode: false),
                        Beacon_major = c.Int(nullable: false),
                        Beacon_minor = c.Int(nullable: false),
                        Beacon_rssi = c.Int(nullable: false),
                        Beacon_trigger_interval = c.Time(precision: 7),
                        Beacon_trigger_proximity = c.String(maxLength: 10, unicode: false),
                        Beacon_message = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Beacon_id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Category_id = c.Int(nullable: false),
                        Category_name = c.String(nullable: false, unicode: false),
                    })
                .PrimaryKey(t => t.Category_id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Admin_type_id = c.Int(nullable: false),
                        Admin_firstname = c.String(),
                        Admin_lastname = c.String(),
                        Admin_gender = c.String(),
                        Admin_dob = c.DateTime(),
                        Admin_aadhar_id = c.Decimal(precision: 18, scale: 2),
                        Admin_pan_card = c.Decimal(precision: 18, scale: 2),
                        Admin_gst_id = c.Decimal(precision: 18, scale: 2),
                        Admin_status = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.LoginProvider)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRoles", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Admin_type_id = c.Int(nullable: false),
                        Admin_firstname = c.String(),
                        Admin_lastname = c.String(),
                        Admin_gender = c.String(),
                        Admin_dob = c.DateTime(),
                        Admin_aadhar_id = c.Decimal(precision: 18, scale: 2),
                        Admin_pan_card = c.Decimal(precision: 18, scale: 2),
                        Admin_gst_id = c.Decimal(precision: 18, scale: 2),
                        Admin_status = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Account_Admin",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        Admin_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_id, t.Admin_id })
                .ForeignKey("dbo.Accounts", t => t.Account_id, cascadeDelete: true)
                .ForeignKey("dbo.Admin", t => t.Admin_id, cascadeDelete: true)
                .Index(t => t.Account_id)
                .Index(t => t.Admin_id);
            
            CreateTable(
                "dbo.Account_Beacon",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        Beacon_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_id, t.Beacon_id })
                .ForeignKey("dbo.Accounts", t => t.Account_id, cascadeDelete: true)
                .ForeignKey("dbo.Beacon", t => t.Beacon_id, cascadeDelete: true)
                .Index(t => t.Account_id)
                .Index(t => t.Beacon_id);
            
            CreateTable(
                "dbo.Account_Category",
                c => new
                    {
                        Account_id = c.Int(nullable: false),
                        Category_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Account_id, t.Category_id })
                .ForeignKey("dbo.Accounts", t => t.Account_id, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_id, cascadeDelete: true)
                .Index(t => t.Account_id)
                .Index(t => t.Category_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserLogins", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserClaims", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropForeignKey("dbo.IdentityUserRoles", "IdentityRole_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Account_Category", "Category_id", "dbo.Categories");
            DropForeignKey("dbo.Account_Category", "Account_id", "dbo.Accounts");
            DropForeignKey("dbo.Account_Beacon", "Beacon_id", "dbo.Beacon");
            DropForeignKey("dbo.Account_Beacon", "Account_id", "dbo.Accounts");
            DropForeignKey("dbo.Account_Admin", "Admin_id", "dbo.Admin");
            DropForeignKey("dbo.Account_Admin", "Account_id", "dbo.Accounts");
            DropForeignKey("dbo.Module", "Admin_type_id", "dbo.AdminTypes");
            DropForeignKey("dbo.Rights", "Right1_Right_id", "dbo.Rights");
            DropForeignKey("dbo.Module", "Right_id", "dbo.Rights");
            DropForeignKey("dbo.Admin", "Admin_type_id", "dbo.AdminTypes");
            DropForeignKey("dbo.Accounts_branch", "Account_id", "dbo.Accounts");
            DropForeignKey("dbo.Accounts_branch", "Timing_id", "dbo.Timing_Table");
            DropForeignKey("dbo.Account_Branches", "Account_id", "dbo.Accounts");
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Account_Category", new[] { "Category_id" });
            DropIndex("dbo.Account_Category", new[] { "Account_id" });
            DropIndex("dbo.Account_Beacon", new[] { "Beacon_id" });
            DropIndex("dbo.Account_Beacon", new[] { "Account_id" });
            DropIndex("dbo.Account_Admin", new[] { "Admin_id" });
            DropIndex("dbo.Account_Admin", new[] { "Account_id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRoles", new[] { "IdentityRole_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Rights", new[] { "Right1_Right_id" });
            DropIndex("dbo.Module", new[] { "Right_id" });
            DropIndex("dbo.Module", new[] { "Admin_type_id" });
            DropIndex("dbo.Admin", new[] { "Admin_type_id" });
            DropIndex("dbo.Accounts_branch", new[] { "Account_id" });
            DropIndex("dbo.Accounts_branch", new[] { "Timing_id" });
            DropIndex("dbo.Account_Branches", new[] { "Account_id" });
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Account_Category");
            DropTable("dbo.Account_Beacon");
            DropTable("dbo.Account_Admin");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.ApplicationUsers");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Categories");
            DropTable("dbo.Beacon");
            DropTable("dbo.Rights");
            DropTable("dbo.Module");
            DropTable("dbo.AdminTypes");
            DropTable("dbo.Admin");
            DropTable("dbo.Timing_Table");
            DropTable("dbo.Accounts_branch");
            DropTable("dbo.Accounts");
            DropTable("dbo.Account_Branches");
        }
    }
}

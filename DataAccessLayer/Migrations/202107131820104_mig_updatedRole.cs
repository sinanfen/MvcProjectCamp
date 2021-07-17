namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_updatedRole : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Admins", name: "Role_RoleId", newName: "RoleId");
            RenameIndex(table: "dbo.Admins", name: "IX_Role_RoleId", newName: "IX_RoleId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Admins", name: "IX_RoleId", newName: "IX_Role_RoleId");
            RenameColumn(table: "dbo.Admins", name: "RoleId", newName: "Role_RoleId");
        }
    }
}

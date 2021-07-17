namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _mig_addWriterNickname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterNickname", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterNickname");
        }
    }
}

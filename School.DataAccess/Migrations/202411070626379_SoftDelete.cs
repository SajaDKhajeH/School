namespace School.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoftDelete : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Students", "DeleteTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DeleteTime");
            DropColumn("dbo.Students", "Deleted");
        }
    }
}

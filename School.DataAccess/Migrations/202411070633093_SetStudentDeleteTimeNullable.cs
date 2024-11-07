namespace School.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetStudentDeleteTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "DeleteTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "DeleteTime", c => c.DateTime(nullable: false));
        }
    }
}

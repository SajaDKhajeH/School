namespace School.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetMaxLengthToStudentProps : DbMigration
    {
        public override void Up()
        {
            Sql("update Students set FirstName='' where FirstName is null");
            Sql("update Students set FirstName='' where len(FirstName)>128");
            Sql("update Students set LastName='' where len(LastName)>128");
            Sql("update Students set Mobile='' where len(Mobile)>128");

            AlterColumn("dbo.Students", "FirstName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "LastName", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Students", "Mobile", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Mobile", c => c.String());
            AlterColumn("dbo.Students", "LastName", c => c.String());
            AlterColumn("dbo.Students", "FirstName", c => c.String());
        }
    }
}

namespace School.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegisterRelations : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Registers", "StudentId");
            CreateIndex("dbo.Registers", "ClassId");
            AddForeignKey("dbo.Registers", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Registers", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registers", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Registers", "ClassId", "dbo.Classes");
            DropIndex("dbo.Registers", new[] { "ClassId" });
            DropIndex("dbo.Registers", new[] { "StudentId" });
        }
    }
}

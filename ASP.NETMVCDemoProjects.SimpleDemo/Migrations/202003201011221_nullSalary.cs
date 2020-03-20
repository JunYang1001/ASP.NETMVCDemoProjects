namespace ASP.NETMVCDemoProjects.SimpleDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullSalary : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TblEmployee", "Salary", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TblEmployee", "Salary", c => c.Int(nullable: false));
        }
    }
}

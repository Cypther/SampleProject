namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "testing", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "testing");
        }
    }
}

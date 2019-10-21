namespace SampleProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicles", "testing");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicles", "testing", c => c.String());
        }
    }
}

namespace DatabaseRelated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedescriptionFromtableStudent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Description", c => c.String());
        }
    }
}

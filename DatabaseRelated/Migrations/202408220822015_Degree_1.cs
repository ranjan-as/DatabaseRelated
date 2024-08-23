namespace DatabaseRelated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Degree_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Degrees",
                c => new
                    {
                        DegreeId = c.Int(nullable: false, identity: true),
                        DegreeName = c.String(),
                    })
                .PrimaryKey(t => t.DegreeId);
            
            AddColumn("dbo.Students", "Degree_DegreeId", c => c.Int());
            CreateIndex("dbo.Students", "Degree_DegreeId");
            AddForeignKey("dbo.Students", "Degree_DegreeId", "dbo.Degrees", "DegreeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Degree_DegreeId", "dbo.Degrees");
            DropIndex("dbo.Students", new[] { "Degree_DegreeId" });
            DropColumn("dbo.Students", "Degree_DegreeId");
            DropTable("dbo.Degrees");
        }
    }
}

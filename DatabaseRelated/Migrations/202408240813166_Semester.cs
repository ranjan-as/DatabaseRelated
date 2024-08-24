namespace DatabaseRelated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Semester : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semeters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(),
                    })
                .PrimaryKey(t => t.SemesterId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Semeters");
        }
    }
}

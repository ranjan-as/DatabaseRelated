﻿namespace DatabaseRelated.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FatherNameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "FName");
        }
    }
}

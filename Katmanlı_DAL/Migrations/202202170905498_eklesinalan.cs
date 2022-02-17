namespace Katmanlı_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eklesinalan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sinifs", "sinifMevcut", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sinifs", "sinifMevcut");
        }
    }
}

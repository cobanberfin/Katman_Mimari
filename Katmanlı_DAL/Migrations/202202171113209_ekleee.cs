namespace Katmanlı_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ekleee : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Ogrencis", name: "SinifID", newName: "Kademe");
            RenameIndex(table: "dbo.Ogrencis", name: "IX_SinifID", newName: "IX_Kademe");
            AddColumn("dbo.Sinifs", "Kademe", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sinifs", "Kademe");
            RenameIndex(table: "dbo.Ogrencis", name: "IX_Kademe", newName: "IX_SinifID");
            RenameColumn(table: "dbo.Ogrencis", name: "Kademe", newName: "SinifID");
        }
    }
}

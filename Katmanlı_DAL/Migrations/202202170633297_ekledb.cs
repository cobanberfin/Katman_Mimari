namespace Katmanlı_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ekledb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ogrencis",
                c => new
                    {
                        OgrenciID = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false),
                        Soyad = c.String(),
                        Adres = c.String(),
                        Yas = c.DateTime(nullable: false),
                        SinifID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OgrenciID)
                .ForeignKey("dbo.Sinifs", t => t.SinifID, cascadeDelete: true)
                .Index(t => t.SinifID);
            
            CreateTable(
                "dbo.Sinifs",
                c => new
                    {
                        SinifID = c.Int(nullable: false, identity: true),
                        Sube = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SinifID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "SinifID", "dbo.Sinifs");
            DropIndex("dbo.Ogrencis", new[] { "SinifID" });
            DropTable("dbo.Sinifs");
            DropTable("dbo.Ogrencis");
        }
    }
}

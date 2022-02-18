namespace KatmanlıMimari.Migrations
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
                        Yas = c.Int(nullable: false),
                        Kademe = c.Int(nullable: false),
                        Sube = c.String(),
                    })
                .PrimaryKey(t => t.OgrenciID)
                .ForeignKey("dbo.Sinifs", t => t.Kademe, cascadeDelete: true)
                .Index(t => t.Kademe);
            
            CreateTable(
                "dbo.Sinifs",
                c => new
                    {
                        SinifID = c.Int(nullable: false, identity: true),
                        Kademe = c.String(nullable: false),
                        Sube = c.String(nullable: false),
                        sinifMevcut = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SinifID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencis", "Kademe", "dbo.Sinifs");
            DropIndex("dbo.Ogrencis", new[] { "Kademe" });
            DropTable("dbo.Sinifs");
            DropTable("dbo.Ogrencis");
        }
    }
}

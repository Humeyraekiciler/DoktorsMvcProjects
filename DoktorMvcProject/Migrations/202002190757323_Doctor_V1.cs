namespace DoktorMvcProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Doctor_V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor_IllPerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        IllPersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.IllPersons", t => t.IllPersonId, cascadeDelete: false)
                .Index(t => t.DoctorId)
                .Index(t => t.IllPersonId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        Phone = c.String(),
                        TitleId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Titles", t => t.TitleId, cascadeDelete: false)
                .Index(t => t.TitleId);
            
            CreateTable(
                "dbo.Dialogues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        IllPersonId = c.Int(nullable: false),
                        DP_Dialogue = c.String(),
                        Writer = c.Boolean(nullable: false),
                        DP_Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.DoctorId, cascadeDelete: false)
                .ForeignKey("dbo.IllPersons", t => t.IllPersonId, cascadeDelete: false)
                .Index(t => t.DoctorId)
                .Index(t => t.IllPersonId);
            
            CreateTable(
                "dbo.IllPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Email = c.String(),
                        Phone = c.String(),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        IdendityNo = c.String(),
                        BirthDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Doctors", "TitleId", "dbo.Titles");
            DropForeignKey("dbo.Dialogues", "IllPersonId", "dbo.IllPersons");
            DropForeignKey("dbo.Doctor_IllPerson", "IllPersonId", "dbo.IllPersons");
            DropForeignKey("dbo.Dialogues", "DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Doctor_IllPerson", "DoctorId", "dbo.Doctors");
            DropIndex("dbo.Dialogues", new[] { "IllPersonId" });
            DropIndex("dbo.Dialogues", new[] { "DoctorId" });
            DropIndex("dbo.Doctors", new[] { "TitleId" });
            DropIndex("dbo.Doctor_IllPerson", new[] { "IllPersonId" });
            DropIndex("dbo.Doctor_IllPerson", new[] { "DoctorId" });
            DropTable("dbo.Users");
            DropTable("dbo.Titles");
            DropTable("dbo.IllPersons");
            DropTable("dbo.Dialogues");
            DropTable("dbo.Doctors");
            DropTable("dbo.Doctor_IllPerson");
        }
    }
}

namespace ProjektStatki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usersAndAchievement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        description = c.String(),
                        wasUnlocked = c.Boolean(nullable: false),
                        HumanPlayer_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.HumanPlayers", t => t.HumanPlayer_id)
                .Index(t => t.HumanPlayer_id);
            
            CreateTable(
                "dbo.HumanPlayers",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                        password = c.String(),
                        raitingPoints = c.Int(nullable: false),
                        level_level = c.Int(nullable: false),
                        level_exp = c.Int(nullable: false),
                        level_expToNextLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achievements", "HumanPlayer_id", "dbo.HumanPlayers");
            DropIndex("dbo.Achievements", new[] { "HumanPlayer_id" });
            DropTable("dbo.HumanPlayers");
            DropTable("dbo.Achievements");
        }
    }
}

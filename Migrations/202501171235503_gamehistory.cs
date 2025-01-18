namespace ProjektStatki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamehistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameHistoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Player1ID = c.Int(nullable: false),
                        Player2ID = c.Int(nullable: false),
                        GameDate = c.DateTime(nullable: false),
                        Result = c.String(),
                        GameModeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GameHistoryModels");
        }
    }
}

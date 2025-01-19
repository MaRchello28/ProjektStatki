namespace ProjektStatki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gamehistoryupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameHistoryModels", "Player1ID", c => c.String());
            AlterColumn("dbo.GameHistoryModels", "Player2ID", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameHistoryModels", "Player2ID", c => c.Int(nullable: false));
            AlterColumn("dbo.GameHistoryModels", "Player1ID", c => c.Int(nullable: false));
        }
    }
}

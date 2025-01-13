namespace ProjektStatki.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version30 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Achievements", new[] { "HumanPlayer_id" });
            CreateIndex("dbo.Achievements", "HumanPlayer_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Achievements", new[] { "HumanPlayer_Id" });
            CreateIndex("dbo.Achievements", "HumanPlayer_id");
        }
    }
}

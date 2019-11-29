namespace Demo002.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "MemberId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "MemberId", c => c.String(unicode: false));
        }
    }
}

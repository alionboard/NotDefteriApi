namespace NotDefteriApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Notlar", "Icerik", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Notlar", "Icerik", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}

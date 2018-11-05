namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Continue01_11_2018 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Birthdate", c => c.DateTime());
        }
    }
}

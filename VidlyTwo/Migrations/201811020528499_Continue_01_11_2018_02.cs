namespace VidlyTwo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Continue_01_11_2018_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}

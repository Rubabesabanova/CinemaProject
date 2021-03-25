namespace MovieProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingValidations2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 255));
        }
    }
}

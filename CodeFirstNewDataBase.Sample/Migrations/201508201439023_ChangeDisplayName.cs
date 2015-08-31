namespace CodeFirstNewDataBase.Sample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDisplayName : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Display", newName: "display_name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Users", name: "display_name", newName: "Display");
        }
    }
}

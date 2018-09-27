namespace CustomersModule.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "ID");
            DropColumn("dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Customers");
            DropColumn("dbo.Customers", "ID");
            AddPrimaryKey("dbo.Customers", "CustomerID");
        }
    }
}

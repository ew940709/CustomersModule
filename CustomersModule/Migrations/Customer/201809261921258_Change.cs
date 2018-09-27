namespace CustomersModule.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropPrimaryKey("dbo.Addresses");
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddPrimaryKey("dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses", "AddressID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Customers", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Customers", "CustomerID");
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses", "AddressID");
        }
    }
}

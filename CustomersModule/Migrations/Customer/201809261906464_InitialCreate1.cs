namespace CustomersModule.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses", "AddressID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropPrimaryKey("dbo.Addresses");
            AlterColumn("dbo.Addresses", "AddressID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Addresses", "AddressID");
            AddForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses", "AddressID");
        }
    }
}

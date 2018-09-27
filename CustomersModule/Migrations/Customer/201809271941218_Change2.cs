namespace CustomersModule.Migrations.Customer
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "Address_AddressID" });
            AddColumn("dbo.Customers", "Street", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "HouseNumber", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "ZipCode", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Address_AddressID");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        HouseNumber = c.String(nullable: false),
                        City = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AddressID);
            
            AddColumn("dbo.Customers", "Address_AddressID", c => c.Int());
            DropColumn("dbo.Customers", "ZipCode");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "HouseNumber");
            DropColumn("dbo.Customers", "Street");
            CreateIndex("dbo.Customers", "Address_AddressID");
            AddForeignKey("dbo.Customers", "Address_AddressID", "dbo.Addresses", "AddressID");
        }
    }
}

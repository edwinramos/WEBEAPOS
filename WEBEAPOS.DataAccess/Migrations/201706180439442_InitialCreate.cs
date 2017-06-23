namespace WEBEAPOS.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_BILLDETAILS",
                c => new
                    {
                        BillDetailId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        QuantityPrice = c.Double(nullable: false),
                        Discount = c.Double(nullable: false),
                        DiscountPrice = c.Double(nullable: false),
                        ProductId = c.Int(nullable: false),
                        BillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillDetailId)
                .ForeignKey("dbo.TBL_BILLS", t => t.BillId, cascadeDelete: true)
                .ForeignKey("dbo.TBL_PRODUCTS", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.BillDetailId, unique: true)
                .Index(t => t.ProductId)
                .Index(t => t.BillId);
            
            CreateTable(
                "dbo.TBL_BILLS",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        BillDate = c.DateTime(nullable: false),
                        TotalAmout = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        BillDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BillId)
                .ForeignKey("dbo.TBL_CLIENTS", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.BillId, unique: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.TBL_CLIENTS",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ClientId)
                .Index(t => t.ClientId, unique: true);
            
            CreateTable(
                "dbo.TBL_PRODUCTS",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Barcode = c.String(),
                        ProductName = c.String(),
                        Description = c.String(),
                        SupplierPrice = c.Double(nullable: false),
                        MarginPercentage = c.Double(nullable: false),
                        FinalPrice = c.Double(nullable: false),
                        BuyDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.TBL_SUPPLIERS", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.ProductId, unique: true)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.TBL_BRANCH_PRODUCTS",
                c => new
                    {
                        BranchId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BranchId, t.ProductId })
                .ForeignKey("dbo.TBL_PRODUCTS", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TBL_BRANCHES", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BranchId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.TBL_SUPPLIERS",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        PhoneNumber = c.String(),
                        ContactName = c.String(),
                        ContactPhone = c.String(),
                        ContactTitle = c.String(),
                        Email = c.String(),
                        WebPage = c.String(),
                        SupplierType = c.String(),
                    })
                .PrimaryKey(t => t.SupplierId)
                .Index(t => t.SupplierId, unique: true);
            
            CreateTable(
                "dbo.TBL_BRANCHES",
                c => new
                    {
                        BranchId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                        Municipio = c.String(),
                        TaxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BranchId)
                .ForeignKey("dbo.TBL_TAXES", t => t.TaxId, cascadeDelete: true)
                .Index(t => t.BranchId, unique: true)
                .Index(t => t.TaxId);
            
            CreateTable(
                "dbo.TBL_TAXES",
                c => new
                    {
                        TaxId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Percentage = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.TaxId)
                .Index(t => t.TaxId, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_BRANCHES", "TaxId", "dbo.TBL_TAXES");
            DropForeignKey("dbo.TBL_BRANCH_PRODUCTS", "BranchId", "dbo.TBL_BRANCHES");
            DropForeignKey("dbo.TBL_BILLDETAILS", "ProductId", "dbo.TBL_PRODUCTS");
            DropForeignKey("dbo.TBL_PRODUCTS", "SupplierId", "dbo.TBL_SUPPLIERS");
            DropForeignKey("dbo.TBL_BRANCH_PRODUCTS", "ProductId", "dbo.TBL_PRODUCTS");
            DropForeignKey("dbo.TBL_BILLS", "ClientId", "dbo.TBL_CLIENTS");
            DropForeignKey("dbo.TBL_BILLDETAILS", "BillId", "dbo.TBL_BILLS");
            DropIndex("dbo.TBL_TAXES", new[] { "TaxId" });
            DropIndex("dbo.TBL_BRANCHES", new[] { "TaxId" });
            DropIndex("dbo.TBL_BRANCHES", new[] { "BranchId" });
            DropIndex("dbo.TBL_SUPPLIERS", new[] { "SupplierId" });
            DropIndex("dbo.TBL_BRANCH_PRODUCTS", new[] { "ProductId" });
            DropIndex("dbo.TBL_BRANCH_PRODUCTS", new[] { "BranchId" });
            DropIndex("dbo.TBL_PRODUCTS", new[] { "SupplierId" });
            DropIndex("dbo.TBL_PRODUCTS", new[] { "ProductId" });
            DropIndex("dbo.TBL_CLIENTS", new[] { "ClientId" });
            DropIndex("dbo.TBL_BILLS", new[] { "ClientId" });
            DropIndex("dbo.TBL_BILLS", new[] { "BillId" });
            DropIndex("dbo.TBL_BILLDETAILS", new[] { "BillId" });
            DropIndex("dbo.TBL_BILLDETAILS", new[] { "ProductId" });
            DropIndex("dbo.TBL_BILLDETAILS", new[] { "BillDetailId" });
            DropTable("dbo.TBL_TAXES");
            DropTable("dbo.TBL_BRANCHES");
            DropTable("dbo.TBL_SUPPLIERS");
            DropTable("dbo.TBL_BRANCH_PRODUCTS");
            DropTable("dbo.TBL_PRODUCTS");
            DropTable("dbo.TBL_CLIENTS");
            DropTable("dbo.TBL_BILLS");
            DropTable("dbo.TBL_BILLDETAILS");
        }
    }
}

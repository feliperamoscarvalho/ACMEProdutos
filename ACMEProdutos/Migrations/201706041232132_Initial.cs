namespace ACMEProdutos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ItensPedidos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        IDPedido = c.Int(nullable: false),
                        IDProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pedidos", t => t.IDPedido, cascadeDelete: true)
                .ForeignKey("dbo.Produtos", t => t.IDProduto, cascadeDelete: true)
                .Index(t => t.IDPedido)
                .Index(t => t.IDProduto);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.String(),
                        Status = c.Int(nullable: false),
                        IDCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.IDCliente, cascadeDelete: true)
                .Index(t => t.IDCliente);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estoque = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensPedidos", "IDProduto", "dbo.Produtos");
            DropForeignKey("dbo.ItensPedidos", "IDPedido", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "IDCliente", "dbo.Clientes");
            DropIndex("dbo.Pedidos", new[] { "IDCliente" });
            DropIndex("dbo.ItensPedidos", new[] { "IDProduto" });
            DropIndex("dbo.ItensPedidos", new[] { "IDPedido" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Pedidos");
            DropTable("dbo.ItensPedidos");
            DropTable("dbo.Clientes");
        }
    }
}

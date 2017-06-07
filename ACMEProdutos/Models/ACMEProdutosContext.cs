using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ACMEProdutos.Models
{
    public class ACMEProdutosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ACMEProdutosContext() : base("name=ACMEProdutosContext")
        {
        }

        public System.Data.Entity.DbSet<ACMEProdutos.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<ACMEProdutos.Models.Produto> Produtos { get; set; }

        public System.Data.Entity.DbSet<ACMEProdutos.Models.Pedido> Pedidos { get; set; }

        public System.Data.Entity.DbSet<ACMEProdutos.Models.ItemPedido> ItemPedidos { get; set; }
    }
}

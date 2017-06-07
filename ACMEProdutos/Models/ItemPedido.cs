using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACMEProdutos.Models
{
    [Table("ItensPedidos")]
    public class ItemPedido
    {
        public int ID { get; set; }
        [Required]
        public int Quantidade { get; set; }
        public int IDPedido { get; set; }
        public int IDProduto { get; set; }

        [ForeignKey("IDPedido")]
        public Pedido Pedido { get; set;
        }
        [ForeignKey("IDProduto")]
        public Produto Produto { get; set; }
      
    }
}
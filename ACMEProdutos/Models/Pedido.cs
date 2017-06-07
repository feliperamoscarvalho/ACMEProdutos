using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ACMEProdutos.Models
{
    [Table("Pedidos")]
    public class Pedido
    {
        public int ID { get; set; }
        [Required]
        public decimal Valor { get; set; }
        public string Data { get; set; }
        [Required]
        public StatusEntrega Status { get; set; } //usando enum StatusEntrega
        public int IDCliente { get; set; }

        [ForeignKey("IDCliente")]
        public Cliente Cliente { get; set; }
    }
}
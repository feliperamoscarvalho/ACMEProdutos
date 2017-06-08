using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ACMEProdutos.Models;

namespace ACMEProdutos.Controllers
{
    public class ItensPedidosController : ApiController
    {
        private ACMEProdutosContext db = new ACMEProdutosContext();

        // GET: api/ItensPedidos
        public IQueryable<ItemPedido> GetItemPedidoes()
        {
            return db.ItemPedidos;
        }

        // GET: api/ItensPedidos/5
        [ResponseType(typeof(ItemPedido))]
        public IHttpActionResult GetItemPedido(int id)
        {
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            return Ok(itemPedido);
        }

        // PUT: api/ItensPedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutItemPedido(int id, ItemPedido itemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemPedido.ID)
            {
                return BadRequest();
            }

            db.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemPedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ItensPedidos
        [ResponseType(typeof(ItemPedido))]
        public IHttpActionResult PostItemPedido(ItemPedido itemPedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Pedido pedido = db.Pedidos.Find(itemPedido.IDPedido);
            if (pedido == null)
            {
                var resposta = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Pedido não encontrado"),
                    ReasonPhrase = "Pedido não encontrado"
                };
                throw new HttpResponseException(resposta);
            }

            Produto produto = db.Produtos.Find(itemPedido.IDProduto);
            if (produto == null)
            {
                var resposta = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Produto não encontrado"),
                    ReasonPhrase = "Produto não encontrado"
                };
                throw new HttpResponseException(resposta);
            }
            
            if(itemPedido.Quantidade > produto.Estoque)
            {
                var resposta = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("A quantidade pedida para o produto não está disponível em estoque"),
                    ReasonPhrase = "Estoque insuficiente"
                };
                throw new HttpResponseException(resposta);
            }

            db.ItemPedidos.Add(itemPedido);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = itemPedido.ID }, itemPedido);
        }

        // DELETE: api/ItensPedidos/5
        [ResponseType(typeof(ItemPedido))]
        public IHttpActionResult DeleteItemPedido(int id)
        {
            ItemPedido itemPedido = db.ItemPedidos.Find(id);
            if (itemPedido == null)
            {
                return NotFound();
            }

            db.ItemPedidos.Remove(itemPedido);
            db.SaveChanges();

            return Ok(itemPedido);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemPedidoExists(int id)
        {
            return db.ItemPedidos.Count(e => e.ID == id) > 0;
        }
    }
}
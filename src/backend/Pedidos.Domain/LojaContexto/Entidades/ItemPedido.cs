using Pedidos.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Entidades
{
    public class ItemPedido: EntidadeBase
    {
        public ItemPedido(Pedido pedido, Produto produto, decimal quantidade)
        {
            this.Pedido = pedido;
            this.Produto = produto;
            this.Quantidade = quantidade;
            this.Preco = produto.Preco;
        }
        public Pedido Pedido { get; private set; }
        public Produto Produto { get; private set; }
        public decimal Quantidade { get; private set; }
        public decimal Preco { get; private set; }


        public void AdicioarPreco(decimal preco)
        {
            this.Preco = preco;
        }
 
    }
}

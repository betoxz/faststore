using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Entidades
{
    public class Pedido : EntidadeBase
    {
        private readonly IList<ItemPedido> _itens;

        public Pedido() { }
        public Pedido(Cliente cliente, EnumPedidoStatus status)
        {
            this.Cliente = cliente;
            this.Status = status;
            this.CriadoEm = DateTime.Now;
            this._itens = new List<ItemPedido>();
        }
        public Cliente Cliente { get; private set; }
        public EnumPedidoStatus Status { get; private set; }
        public IReadOnlyCollection<ItemPedido> Itens => _itens.ToArray();
        public void AdicionarItem(ItemPedido item)
        {
            _itens.Add(item);
        }

        public void AlterarStatus(EnumPedidoStatus status)
        {
            this.Status = status;
            this.AtualizadoEm = DateTime.Now;
        }

        public IReadOnlyCollection<ItemPedido> ListarItens()
        {
            return this.Itens;
        }

        //public Pedido LocalizarPedido(Guid idPedido)
        //{
        //    //pesquisar na base
        //    return new Pedido(new Cliente("", ""), EnumPedidoStatus.Aguardando);
        //}
    }
}

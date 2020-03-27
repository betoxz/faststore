using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Queries
{
    public class ListItensPedidoQueryResult
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public Decimal Preco { get; set; }
        public Decimal Total { get; set; }
    }
}

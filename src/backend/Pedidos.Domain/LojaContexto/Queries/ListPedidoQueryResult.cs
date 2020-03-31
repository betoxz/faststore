using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Queries
{
    public class ListPedidoQueryResult
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public DateTime CriadoEm { get; set; }
        public int Status { get; set; }
        public string Cliente { get; set; }
        public Decimal QuantidadeTotal { get; set; }
        public Decimal ValorTotal { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Enums
{
    public enum EnumPedidoStatus
    {
        [Description("Aguardando")]
        Aguardando = 1,
        [Description("Enviado")]
        Enviado =2,
        [Description("Entregue")]
        Entregue = 3,
        [Description("Cancelado")]
        Cancelado = 4,
        [Description("Pré Venda")]
        PreVenda = 5
    }
}

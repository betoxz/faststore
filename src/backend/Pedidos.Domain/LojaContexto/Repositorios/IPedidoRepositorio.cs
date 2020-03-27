using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Repositorios
{
    public interface IPedidoRepositorio
    {        
        GetPedidoQueryResult GetPedido(int Id);

        void AlteraStatusPedido(int Id, EnumPedidoStatus Status);

        IEnumerable<ListItensPedidoQueryResult> GetItensPedido(int IdPedido);
    }
}

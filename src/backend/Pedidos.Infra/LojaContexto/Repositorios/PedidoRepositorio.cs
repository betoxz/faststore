using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Pedidos.Infra.LojaContexto.DataContexts;
using Pedidos.Domain.LojaContexto.Queries;

namespace Pedidos.Infra.LojaContexto.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly DataContext _context;

        public PedidoRepositorio(DataContext context)
        {
            _context = context;
        }

        //Localizar pedido;
        public IEnumerable<ListPedidoQueryResult> GetPedido(int Id)
        {
            return
                _context
                .Connection
                .Query<ListPedidoQueryResult>(@" Select C.Id, Id_Cliente as IdCliente , CreateAt CriadoEm,Status, C.Nome as Cliente, 
                                                (Select Sum(Quantidade)
                                                FROM ItensPedido 
                                                Where Id_Pedido = @Id) as QuantidadeTotal
                                                ,
                                                (Select Sum(Preco * Quantidade)
                                                FROM ItensPedido 
                                                Where Id_Pedido = @Id) as ValorTotal

                                                FROM Pedidos P
                                                INNER JOIN Clientes C
                                                On C.Id = P.id_Cliente
                                                WHERE P.id = @Id", new { Id });
        }

        //Listar os itens do pedido;
        public IEnumerable<ListItensPedidoQueryResult> GetItensPedido(int IdPedido)
        {
            return
                _context
                .Connection
                .Query<ListItensPedidoQueryResult>(@" Select I.Id, P.Descricao, I.Quantidade, I.Preco, (I.Quantidade * I.Preco) as Total 
                                                FROM ItensPedido I
                                                Inner Join Produtos P
                                                On I.Id_Produto= P.Id WHERE Id_Pedido = @IdPedido", new { IdPedido });
        }

        //Alterar status do pedido;
        public void AlteraStatusPedido(int Id, EnumPedidoStatus Status)
        {
            var ret =
            _context
            .Connection.Query("UPDATE Pedidos SET Status = @Status"
                        + " WHERE Id = @Id", new { Status, Id });
        }

        public IEnumerable<ListPedidoQueryResult> GetPedidos()
        {
            return
             _context
             .Connection
             .Query<ListPedidoQueryResult>(@" Select C.Id, Id_Cliente as IdCliente , CreateAt CriadoEm,Status, C.Nome as Cliente, 
                                                (Select Sum(Quantidade)
                                                FROM ItensPedido 
                                                Where Id_Pedido = P.Id) as QuantidadeTotal
                                                ,
                                                (Select Sum(Preco * Quantidade)
                                                FROM ItensPedido 
                                                Where Id_Pedido = P.Id) as ValorTotal
                                                FROM Pedidos P
                                                INNER JOIN Clientes C
                                                On C.Id = P.id_Cliente ", new { });
        }
    }
}

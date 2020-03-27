using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Domain.LojaContexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PedidoTestes.Mocs
{
    public class MocPedidoRepositorio : IPedidoRepositorio
    {
        public List<Cliente> lista = new List<Cliente>();
        public List<Pedido> listaP = new List<Pedido>();
        public MocPedidoRepositorio()
        {
            MocClienteRepositorio mocCli = new MocClienteRepositorio();

            lista = mocCli.lista;
            listaP.Add(new Pedido(lista[0], EnumPedidoStatus.Aguardando));
            listaP.Add(new Pedido(lista[1], EnumPedidoStatus.Cancelado));
            listaP.Add(new Pedido(lista[2], EnumPedidoStatus.Entregue));
            listaP.Add(new Pedido(lista[3], EnumPedidoStatus.Enviado));
        }

        public bool AlteraStatusPedido(int idPedido, EnumPedidoStatus status)
        {
            return true;
        }

        public GetPedidoQueryResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GetPedidoQueryResult> GetItensPedido(int IdPedido)
        {
            throw new NotImplementedException();
        }

        public GetPedidoQueryResult GetPedido(int Id)
        {
            throw new NotImplementedException();
        }

        public Pedido LocalizarPedido(int idPedido)
        {
            return listaP.Where(x => x.Id == idPedido).LastOrDefault();
        }

        void IPedidoRepositorio.AlteraStatusPedido(int Id, EnumPedidoStatus Status)
        {
            throw new NotImplementedException();
        }

        IEnumerable<ListItensPedidoQueryResult> IPedidoRepositorio.GetItensPedido(int IdPedido)
        {
            throw new NotImplementedException();
        }
    }
}

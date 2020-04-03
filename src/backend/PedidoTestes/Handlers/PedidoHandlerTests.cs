using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.InPuts;
using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Handlers;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Infra.LojaContexto.DataContexts;
using Pedidos.Infra.LojaContexto.Repositorios;
using PedidoTestes.Mocs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PedidoTestes.Handlers
{
    [TestClass]
    public class PedidoHandlerTests
    {

        [TestMethod]
        public void DeveAlterarStatusPedido()
        {
            //List<ListStatusQueryResult> enums = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Select(c => new ListStatusQueryResult() { Chave = c.ToString(), Valor = (int)c  }).ToList();

            // A list of Names only, does away with the need of EnumModel 
            List<string> MyNames = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Select(c => c.ToString()).ToList();

            // A list of Values only, does away with the need of EnumModel 
            List<int> myValues = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).Select(c => (int)c).ToList();

            // A dictionnary of <string,int>
            Dictionary<string, int> myDic = ((EnumPedidoStatus[])Enum.GetValues(typeof(EnumPedidoStatus))).ToDictionary(k => k.ToString(), v => (int)v);


            var ctx = new DataContext();

            //var repo = new PedidoRepositorio(ctx);            

            //repo.AlteraStatusPedido(1, Pedidos.Domain.LojaContexto.Enums.EnumPedidoStatus.Aguardando);

            //repo.AlteraStatusPedido(9, Pedidos.Domain.LojaContexto.Enums.EnumPedidoStatus.Cancelado);

            //var pedi = repo.GetPedido(1);

            //var itens = repo.GetItensPedido(pedi.Id);

            var cli = new ClienteRepositorio(ctx);
            var cc = cli.Get("789.789.789-78");

            var command = new AlteraStatusPedidoCommand();
            MocPedidoRepositorio ped = new MocPedidoRepositorio();

            command.IdPedido = ped.listaP[1].Id;
            command.Status = Pedidos.Domain.LojaContexto.Enums.EnumPedidoStatus.Cancelado;
            Assert.AreEqual(true, command.IsValid);

            var handleR = new PedidoHandler(ped);

            var result = handleR.Handle(command);
        }
    }
}

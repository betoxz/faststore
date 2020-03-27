using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.InPuts;
using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;

namespace PedidoTestes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cliente = new Cliente("Carlos Alberto", "311,651,818-19");
            var pedido = new Pedido(cliente, Pedidos.Domain.LojaContexto.Enums.EnumPedidoStatus.Aguardando);
            pedido.AlterarStatus(EnumPedidoStatus.Entregue);

            //var PesquisaPedido = pedido.LocalizarPedido(pedido.Id);
        }

        [TestMethod]
        public void ValidaAlterarStatus()
        {
            var command = new AlteraStatusPedidoCommand();

            var cliente = new Cliente("Carlos Alberto", "311,651,818-19");
            var pedido = new Pedido(cliente, Pedidos.Domain.LojaContexto.Enums.EnumPedidoStatus.Aguardando);
            command.Status = EnumPedidoStatus.Cancelado;
            Assert.AreEqual(true, command.IsValid);
        }
    }
}

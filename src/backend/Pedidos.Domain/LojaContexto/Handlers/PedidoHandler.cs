using FluentValidator;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.InPuts;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.OutPuts;
using Pedidos.Domain.LojaContexto.Repositorios;
using Pedidos.Shared.Commands;

namespace Pedidos.Domain.LojaContexto.Handlers
{

    public class PedidoHandler : Notifiable,
    ICommandHandler<AlteraStatusPedidoCommand>
    {
        private readonly IPedidoRepositorio _repositorioPedido;
        public PedidoHandler(IPedidoRepositorio repositorioPedido)
        {
            _repositorioPedido = repositorioPedido;
        }

        public ICommandResult Handle(AlteraStatusPedidoCommand command)
        {
            var pedido = _repositorioPedido.GetPedido(command.IdPedido);
            if (pedido is null)
                AddNotification("Pedido", "Pedido não encontrado");

            if (Invalid)
                return new AlteraStatusPedidoCommandResult(
                    false,
                    "Por favor, corrija o pedido",
                    Notifications);

            _repositorioPedido.AlteraStatusPedido(command.IdPedido, command.Status);

            return new AlteraStatusPedidoCommandResult(true, "Status do pedido atualizado com sucesso!", "retorno");
        }
    }
}

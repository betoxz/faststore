using FluentValidator;
using FluentValidator.Validation;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Shared.Commands;
using System;

namespace Pedidos.Domain.LojaContexto.Commands.PedidoCommands.InPuts
{
    public class AlteraStatusPedidoCommand : Notifiable, ICommand
    {
        public int IdPedido { get; set; }
        public EnumPedidoStatus Status { get; set; }
        public DateTime DataAtualizacao { get; set; }

        bool ICommand.Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(IdPedido.ToString(), 36, "IdPedido", "Pedido não pode ser vazio")
                .IsGreaterOrEqualsThan(Status.GetHashCode(), 0, "Status", "Status do pedido inválido")
                );
            return IsValid;
        }
    }
}

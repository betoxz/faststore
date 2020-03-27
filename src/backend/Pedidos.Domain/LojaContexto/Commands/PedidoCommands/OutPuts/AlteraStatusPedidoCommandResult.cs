using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Commands.PedidoCommands.OutPuts
{
    public class AlteraStatusPedidoCommandResult : ICommandResult
    {
        public AlteraStatusPedidoCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}

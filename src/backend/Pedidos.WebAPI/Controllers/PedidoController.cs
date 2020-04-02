using Microsoft.AspNetCore.Mvc;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.InPuts;
using Pedidos.Domain.LojaContexto.Commands.PedidoCommands.OutPuts;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Handlers;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Domain.LojaContexto.Repositorios;
using Pedidos.Shared.Commands;
using System;
using System.Collections.Generic;

namespace Pedidos.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _repositorio;
        private readonly PedidoHandler _handler;

        public PedidoController(IPedidoRepositorio repositorio, PedidoHandler handler)
        {
            _repositorio = repositorio;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/pedidos/{id}")]
        public IEnumerable<ListPedidoQueryResult> GetById(int id)
        {
            return _repositorio.GetPedido(id);
        }
        [HttpGet]
        [Route("v1/pedidos")]
        public IEnumerable<ListPedidoQueryResult> GetPedidos()
        {
            return _repositorio.GetPedidos();
        }

        [HttpGet]
        [Route("v1/pedidos/{id}/itens")]
        public IEnumerable<ListItensPedidoQueryResult> GetItensPedido(int id)
        {
            return _repositorio.GetItensPedido(id);
        }

        [HttpPut]
        [Route("v1/pedido")]
        public ICommandResult Put([FromBody]AlteraStatusPedidoCommand command)
        {
            var result = (AlteraStatusPedidoCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpGet]
        [Route("v1/status")]
        public Dictionary<string, int> GetStatus()
        {
            return new ListStatusQueryResult().Status;
        }        
    }
}

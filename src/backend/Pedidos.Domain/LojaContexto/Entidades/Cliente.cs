using FluentValidator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Entidades
{
    public class Cliente : Notifiable
    {
        private readonly IList<Pedido> _pedidos;
        public Cliente(string nome, string cpf)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            _pedidos = new List<Pedido>();

        }
        //public Guid IdCliente { get; set; }
        
        [Required]
        [MaxLength(255, ErrorMessage = "Tamanho máximo do nome 255")]
        public string Nome { get; private set; }
        [Required]
        [MaxLength(11, ErrorMessage = "Tamanho máximo do Cpf 11 posições ")]
        public string Cpf { get; private set; }
        public IReadOnlyCollection<Pedido> Pedidos => _pedidos.ToArray();

        public void AdicionarPedido(Pedido pedido)
        {
            if (pedido == null)
                AddNotification("Cliente", "Não há pedido para ser incluido");
            _pedidos.Add(pedido);
        }

        public Cliente LocalizarCliente(string cpf)
        {
            //buscar do banco
            var cli = new Cliente("", cpf);
            if (cli== null)
                AddNotification("Cliente", "Nenhum Cliente Localizado para este CPF");
            //pesquisar na service ou repositório
            return cli;
        }
    }
}

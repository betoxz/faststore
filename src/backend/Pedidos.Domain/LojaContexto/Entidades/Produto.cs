using Pedidos.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Entidades
{
    public class Produto : EntidadeBase
    {
        public Produto(string descricao, decimal preco, int status)
        {
            this.Descricao = descricao;
            this.Preco = preco;
            this.Status = status;
        }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Status { get; private set; }
    }
}

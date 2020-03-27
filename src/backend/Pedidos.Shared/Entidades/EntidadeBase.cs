using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Shared.Entidades
{
    public abstract class EntidadeBase : Notifiable
    {
        public EntidadeBase()
        {
            Id = 0;
        }
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
    }
}


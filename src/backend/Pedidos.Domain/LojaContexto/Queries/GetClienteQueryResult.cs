﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Queries
{
    public class GetClienteQueryResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}

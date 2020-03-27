using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.Domain.LojaContexto.Repositorios
{
    public interface IClienteRepositorio
    {
        GetClienteQueryResult Get(string cpf);
    }
}

using Pedidos.Domain.LojaContexto.Entidades;
using Pedidos.Domain.LojaContexto.Enums;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Domain.LojaContexto.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PedidoTestes.Mocs
{
    public class MocClienteRepositorio : IClienteRepositorio
    {
        public List<Cliente> lista = new List<Cliente>();
        public MocClienteRepositorio()
        {
            lista.Add(new Cliente("Carlos", "123.123.123-12"));
            lista.Add(new Cliente("Bianca", "456.456.456-45"));
            lista.Add(new Cliente("Carina", "789.789.789-78"));
            lista.Add(new Cliente("Vinicius", "000.111.222-33"));
        }

        public GetClienteQueryResult Get(string cpf)
        {
            throw new NotImplementedException();
        }

        public Cliente LocalizarClientePorCpf(string cpf)
        {
            return lista.Where(x => x.Cpf == cpf).FirstOrDefault();
        }
    }
}

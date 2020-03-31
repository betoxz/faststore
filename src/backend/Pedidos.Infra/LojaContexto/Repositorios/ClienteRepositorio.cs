using Dapper;
using Pedidos.Domain.LojaContexto.Queries;
using Pedidos.Domain.LojaContexto.Repositorios;
using Pedidos.Infra.LojaContexto.DataContexts;
using System.Collections.Generic;
using System.Linq;

namespace Pedidos.Infra.LojaContexto.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly DataContext _context;

        public ClienteRepositorio(DataContext context)
        {
            _context = context;
        }

        // Módulo Pedidos - Localizar Cliente por CPF;
        public IEnumerable<ListClienteQueryResult> Get(string cpf)
        {
            return
                _context
                .Connection
                .Query<ListClienteQueryResult>(@" Select Id, Nome , Cpf
                                                FROM Clientes 
                                                WHERE Cpf = @Cpf", new { cpf });
        }

        public IEnumerable<ListClienteQueryResult> GetClientes()
        {
            return
                _context
                .Connection
                .Query<ListClienteQueryResult>(@" Select Id, Nome , Cpf
                                                FROM Clientes", new { });
        }
    }
}

using MySql.Data.MySqlClient;
using Dapper;
using System;
using Pedidos.Shared;
using System.Data;

namespace Pedidos.Infra.LojaContexto.DataContexts
{
    public class DataContext : IDisposable
    {
        public MySqlConnection Connection { get; set; }
        public DataContext()
        {
            Connection = new MySqlConnection(Settings.ConnectionStringMySql);
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}

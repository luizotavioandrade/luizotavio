using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class ClienteRepository
    {
        private readonly string ConnectionString;

        public ClienteRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Método para adicionar um cliente
        public void Adicionar(ClienteRepository cliente)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<ClienteRepository>(cliente);
        }

        // Método para remover um cliente por ID
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            ClienteRepository cliente = BuscarPorId(id);
            connection.Delete<ClienteRepository>(cliente);
        }

        // Método para editar os dados de um cliente
        public void Editar(ClienteRepository cliente)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<ClienteRepository>(cliente);
        }

        // Método para listar todos os clientes
        public List<ClienteRepository> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<ClienteRepository>().ToList();
        }

        // Método para buscar um cliente por ID
        public ClienteRepository BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<ClienteRepository>(id);
        }
    }
}

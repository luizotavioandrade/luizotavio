using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class VeiculoRepository
    {
        private readonly string ConnectionString;

        public VeiculoRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Método para adicionar um veículo
        public void Adicionar(VeiculoRepository veiculo)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<VeiculoRepository>(veiculo);
        }

        // Método para remover um veículo por ID
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            VeiculoRepository veiculo = BuscarPorId(id);
            connection.Delete<VeiculoRepository>(veiculo);
        }

        // Método para editar um veículo
        public void Editar(Veiculo veiculo)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Veiculo>(veiculo);
        }

        // Método para listar todos os veículos
        public List<Veiculo> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Veiculo>().ToList();
        }

        // Método para buscar um veículo por ID
        public Veiculo BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Veiculo>(id);
        }
    }
}

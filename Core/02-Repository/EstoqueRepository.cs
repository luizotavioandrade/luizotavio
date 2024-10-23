using Core.Entidades;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;

namespace TrabalhoFinal._02_Repository
{
    public class EstoqueRepository
    {
        private readonly string ConnectionString;

        public EstoqueRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        // Método para adicionar um veículo ao estoque
        public void Adicionar(VeiculoRepository veiculo)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<VeiculoRepository>(veiculo);
        }

        // Método para remover um veículo do estoque por ID
        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            VeiculoRepository veiculo = BuscarPorId(id);
            connection.Delete<VeiculoRepository>(veiculo);
        }

        // Método para editar os dados de um veículo no estoque
        public void Editar(VeiculoRepository veiculo)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<VeiculoRepository>(veiculo);
        }

        // Método para listar todos os veículos no estoque
        public List<VeiculoRepository> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<VeiculoRepository>().ToList();
        }

        // Método para buscar um veículo no estoque por ID
        public VeiculoRepository BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<VeiculoRepository>(id);
        }
    }
}

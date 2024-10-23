using Core.Entidades;
using TrabalhoFinal._02_Repository;

namespace TrabalhoFinal._01_Services
{
    public class EstoqueService
    {
        private readonly EstoqueRepository _repository;

        public EstoqueService(string connectionString)
        {
            _repository = new EstoqueRepository(connectionString);
        }

        public List<VeiculoRepository> Listar()
        {
            return _repository.Listar();
        }

        public VeiculoRepository BuscarPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
        }

        public void Editar(VeiculoRepository carro)
        {
            _repository.Editar(carro);
        }

        public void Editar(global::API.Controllers.VeiculoController carro)
        {
            throw new NotImplementedException();
        }
    }
}

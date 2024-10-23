public class VeiculoService
{
    public VeiculoRepository repository { get; set; }
    public VeiculoService(string _config)
    {
        repository = new VeiculoRepository(_config);
    }

    public void Adicionar(VeiculoService veiculo)
    {
        repository.Adicionar(veiculo);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public List<Veiculo> Listar()
    {
        return repository.Listar();
    }

    public Veiculo BuscarVeiculoPorId(int id)
    {
        return repository.BuscarPorId(id);
    }

    public void Editar(Veiculo veiculoEditado)
    {
        repository.Editar(veiculoEditado);
    }

    private class VeiculoRepository
    {
        private string config;

        public VeiculoRepository(string config)
        {
            this.config = config;
        }
    }
}

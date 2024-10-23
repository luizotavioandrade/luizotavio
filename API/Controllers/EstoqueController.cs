using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrabalhoFinal._01_Services; // Namespace para acessar o EstoqueService
using Core.Entidades; // Namespace para acessar a entidade Veiculo

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _service;

        public EstoqueController(IConfiguration config)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new EstoqueService(_config);
        }

        [HttpGet("listar-carros")]
        public List<VeiculoController> ListarCarros()
        {
            return _service.Listar(); // Método para listar carros
        }

        [HttpGet("buscar-carro/{id}")]
        public VeiculoController BuscarCarro(int id)
        {
            return _service.BuscarPorId(id); // Método para buscar carro por ID
        }

        [HttpDelete("cancelar-compra/{id}")]
        public void CancelarCompra(int id)
        {
            _service.Remover(id); // Método para remover carro (cancelar compra)
        }

        [HttpPut("editar-carro")]
        public void EditarCarro(VeiculoController carro)
        {
            _service.Editar(carro); // Método para editar carro
        }
    }
}

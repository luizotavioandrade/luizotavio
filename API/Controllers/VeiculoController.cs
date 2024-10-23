using AutoMapper;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController : ControllerBase
    {
        private readonly VeiculoService _service; // Mudança de CarrinhoService para VeiculoService
        private readonly IMapper _mapper;

        public VeiculoController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new VeiculoService(_config); // Mudança de CarrinhoService para VeiculoService
            _mapper = mapper;
        }

        [HttpPost("adicionar-veiculo")] // Mudança de adicionar-carrinho para adicionar-veiculo
        public void AdicionarVeiculo(Veiculo veiculoDTO) // Mudança de carrinhoDTO para veiculoDTO
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDTO); // Mudança de Carrinho para Veiculo
            _service.Adicionar(veiculo);
        }

        [HttpGet("listar-veiculos")] // Mudança de listar-carrinho para listar-veiculos
        public List<Veiculo> ListarVeiculos() // Mudança de ListarAluno para ListarVeiculos
        {
            return _service.Listar();
        }

        [HttpPut("editar-veiculo")] // Mudança de editar-carrinho para editar-veiculo
        public void EditarVeiculo(Veiculo veiculo) // Mudança de p para veiculo
        {
            _service.Editar(veiculo);
        }

        [HttpDelete("deletar-veiculo")] // Mudança de deletar-carrinho para deletar-veiculo
        public void DeletarVeiculo(int id) // Mudança de DeletarCarrinho para DeletarVeiculo
        {
            _service.Remover(id);
        }
    }
}

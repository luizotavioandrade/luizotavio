using AutoMapper;
using Core._03_Entidades.DTO.Cliente;
using Core.Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        private readonly IMapper _mapper;

        public ClienteController(IConfiguration config, IMapper mapper)
        {
            string connectionString = config.GetConnectionString("DefaultConnection");
            _service = new ClienteService(connectionString);
            _mapper = mapper;
        }

        [HttpPost("adicionar-cliente")]
        public ActionResult AdicionarCliente([FromBody] Cliente clienteDTO)
        {
            if (clienteDTO == null)
                return BadRequest("Cliente inválido.");

            _service.Adicionar(clienteDTO);
            return CreatedAtAction(nameof(ListarClientes), new { id = clienteDTO.Id }, clienteDTO);
        }

        [HttpPost("fazer-login")]
        public ActionResult<Cliente> FazerLogin([FromBody] Cliente clienteLogin)
        {
            if (clienteLogin == null)
                return BadRequest("Dados de login inválidos.");

            var cliente = _service.FazerLogin(clienteLogin);
            if (cliente == null)
                return Unauthorized();

            return Ok(cliente);
        }

        [HttpGet("listar-clientes")]
        public ActionResult<List<Cliente>> ListarClientes()
        {
            var clientes = ClienteService.Listar();
            return Ok(clientes);
        }

        [HttpPut("editar-cliente")]
        public ActionResult EditarCliente([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest("Cliente inválido.");

            _service.Editar(cliente);
            return NoContent();
        }

        [HttpDelete("deletar-cliente/{id}")]
        public ActionResult DeletarCliente(int id)
        {
            _service.Remover(id);
            return NoContent();
        }
    }
}

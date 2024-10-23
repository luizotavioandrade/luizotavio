using Core._03_Entidades.DTO.Cliente; // Ajuste para o DTO de Cliente
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class ClienteUC
    {
        private readonly HttpClient _client;

        public ClienteUC(HttpClient cliente)
        {
            _client = cliente;
        }

        // Método para listar clientes
        public async Task<List<Cliente>> ListarClientes()
        {
            return await _client.GetFromJsonAsync<List<Cliente>>("Cliente/listar-cliente");
        }

        // Método para cadastrar um novo cliente
        public async Task CadastrarCliente(Cliente cliente)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("Cliente/adicionar-cliente", cliente);
            response.EnsureSuccessStatusCode(); // Lança uma exceção se a resposta não for 2xx
        }

        // Método para fazer login do cliente
        public async Task<Cliente> FazerLogin(ClienteLoginDTO clienteLogin) // Ajuste para o DTO de Cliente
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("Cliente/fazer-login", clienteLogin);
            response.EnsureSuccessStatusCode(); // Lança uma exceção se a resposta não for 2xx
            Cliente cliente = await response.Content.ReadFromJsonAsync<Cliente>();
            return cliente;
        }
    }
}

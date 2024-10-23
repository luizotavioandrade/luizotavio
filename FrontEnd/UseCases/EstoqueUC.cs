using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontEnd.UseCases
{
    public class EstoqueUC : EstoqueUCBase
    {
        private readonly HttpClient _client;

        public EstoqueUC(HttpClient client)
        {
            _client = client;
        }

        // Método para listar carros de forma assíncrona
        public async Task<List<Veiculo>> ListarCarrosAsync()
        {
            try
            {
                var veiculos = await _client.GetFromJsonAsync<List<Veiculo>>("Estoque/listar-carros");
                return veiculos ?? new List<Veiculo>(); // Retorna uma lista vazia se a resposta for nula
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao listar carros: {ex.Message}");
                return new List<Veiculo>(); // Retorna uma lista vazia em caso de erro
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return new List<Veiculo>();
            }
        }

        // Método para buscar carro por ID de forma assíncrona
        public async Task<Veiculo?> BuscarCarroPorIdAsync(int id)
        {
            try
            {
                var veiculo = await _client.GetFromJsonAsync<Veiculo>($"Estoque/buscar-carro/{id}");
                return veiculo; // Pode retornar null se o carro não for encontrado
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro ao buscar carro: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return null;
            }
        }

        // Método para cancelar uma compra de forma assíncrona
        public async Task CancelarCompraAsync(int id)
        {
            try
            {
                var response = await _client.DeleteAsync($"Estoque/cancelar-compra/{id}");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Compra cancelada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao cancelar compra.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro de rede ao cancelar compra: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao cancelar compra: {ex.Message}");
            }
        }

        // Método para registrar uma venda (pode ser implementado mais tarde)
        public async Task RegistrarVendaAsync(int idVeiculo, int idCliente)
        {
            try
            {
                // Implementação do corpo do método de venda
                var venda = new { IdVeiculo = idVeiculo, IdCliente = idCliente };
                var response = await _client.PostAsJsonAsync("Estoque/registrar-venda", venda);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Venda registrada com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro ao registrar venda.");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Erro de rede ao registrar venda: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado ao registrar venda: {ex.Message}");
            }
        }
    }
}

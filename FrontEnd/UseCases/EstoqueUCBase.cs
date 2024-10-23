using System.Net.Http.Json;

namespace FrontEnd.UseCases
{
    public class EstoqueUCBase
    {

        public void EditarCarro(Veiculo carro)
        {
            _client.PutAsJsonAsync("Estoque/editar-carro", carro).Wait(); // Endpoint para editar carro
        }
    }
}
using FrontEnd.UseCases; // Ajuste para incluir o namespace correto
using System.Net.Http.Json;
using System.Text.Json;

HttpClient cliente = new HttpClient
{
    BaseAddress = new Uri("http://localhost:5000/clientes")
};

// Ajuste para refletir o novo contexto da concessionária
EstoqueUC estoqueUC = new EstoqueUC(cliente);
ClienteUC clienteUC = new ClienteUC(cliente);

// Exemplo de uso do sistema com clientes e estoque
async Task IniciarSistema()
{
    // Listar clientes
    var clientes = await clienteUC.ListarClientes();
    foreach (var cliente in clientes)
    {
        Console.WriteLine(cliente.ToString());
    }

    // Listar itens de estoque
    var estoque = await estoqueUC.ListarEstoque();
    foreach (var item in estoque)
    {
        Console.WriteLine(item.ToString());
    }

    // Outras operações podem ser realizadas aqui
}

// Chamada do método para iniciar o sistema
await IniciarSistema();

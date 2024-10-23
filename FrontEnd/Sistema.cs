using Core._03_Entidades.DTO;
using Core.Entidades;
using FrontEnd.UseCases;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd
{
    public class Sistema : SistemaBase
    {
        private static Cliente? ClienteLogado { get; set; }
        private readonly ClienteUC _clienteUC;
        private readonly ProdutoUC _produtoUC;
        private readonly EstoqueUC _estoqueUC; // Adicionado para o gerenciamento do estoque
        private const int OPCAO_LOGIN = 1;
        private const int OPCAO_CADASTRAR = 2;
        private const int OPCAO_LISTAR_CLIENTES = 3;
        private const int OPCAO_LISTAR_PRODUTOS = 4;
        private const int OPCAO_CADASTRAR_PRODUTO = 5;
        private const int OPCAO_LISTAR_CARROS = 6;
        private const int OPCAO_CANCELAR_COMPRA = 7;
        private const int OPCAO_EDITAR_CARRO = 8;
        private const int OPCAO_CANCELAR = 0;

        public Sistema(HttpClient cliente)
        {
            _clienteUC = new ClienteUC(cliente);
            _produtoUC = new ProdutoUC(cliente);
            _estoqueUC = new EstoqueUC(cliente);
        }

        public async Task IniciarSistemaAsync()
        {
            int resposta = -1;
            while (resposta != OPCAO_CANCELAR)
            {
                resposta = ClienteLogado == null ? await ExibirLoginMenuAsync() : await ExibirMenuPrincipalAsync();
            }
        }

        private Task<int> ExibirLoginMenuAsync()
        {
            throw new NotImplementedException();
        }

        private async Task<int> ExibirMenuPrincipalAsync()
        {
            Console.WriteLine("--------- MENU PRINCIPAL ---------");
            Console.WriteLine("1 - Listar Produtos");
            Console.WriteLine("2 - Cadastrar Produto");
            Console.WriteLine("3 - Listar Clientes Cadastrados");
            Console.WriteLine("4 - Listar Carros");
            Console.WriteLine("5 - Cancelar Compra");
            Console.WriteLine("6 - Editar Carro");
            Console.WriteLine($"{OPCAO_CANCELAR} - Voltar/Cancelar");
            Console.WriteLine("Qual operação deseja realizar?");

            if (int.TryParse(Console.ReadLine(), out int escolha))
            {
                switch (escolha)
                {
                    case OPCAO_LISTAR_PRODUTOS:
                        await ListarProdutosAsync();
                        break;
                    case OPCAO_CADASTRAR_PRODUTO:
                        await CadastrarProdutoAsync();
                        break;
                    case OPCAO_LISTAR_CLIENTES:
                        await ListarClientesCadastradosAsync();
                        break;
                    case OPCAO_LISTAR_CARROS:
                        await ListarCarrosAsync();
                        break;
                    case OPCAO_CANCELAR_COMPRA:
                        await CancelarCompraAsync();
                        break;
                    case OPCAO_EDITAR_CARRO:
                        await EditarCarroAsync();
                        break;
                }
                return escolha;
            }
            return -1;
        }

        private async Task ListarCarrosAsync()
        {
            try
            {
                List<Veiculo> veiculos = await _estoqueUC.ListarCarrosAsync(); // Método para listar carros no estoque
                if (veiculos.Count == 0)
                {
                    Console.WriteLine("Nenhum carro encontrado no estoque.");
                }
                else
                {
                    foreach (Veiculo v in veiculos)
                    {
                        Console.WriteLine(v.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar carros: {ex.Message}");
            }
        }

        private async Task CancelarCompraAsync()
        {
            Console.WriteLine("Digite o ID do carro que deseja cancelar a compra: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    await _estoqueUC.CancelarCompraAsync(id); // Método para cancelar compra
                    Console.WriteLine("Compra cancelada com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cancelar compra: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private async Task EditarCarroAsync()
        {
            Console.WriteLine("Digite o ID do carro que deseja editar: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                try
                {
                    Veiculo? carro = await _estoqueUC.BuscarCarroPorIdAsync(id); // Método para buscar carro por ID
                    if (carro != null)
                    {
                        Console.WriteLine("Digite o novo nome do carro: ");
                        carro.Nome = Console.ReadLine();
                        Console.WriteLine("Digite o novo preço do carro: ");
                        if (double.TryParse(Console.ReadLine(), out double preco))
                        {
                            carro.Preco = preco;
                            await _estoqueUC.EditarCarroAsync(carro); // Método para editar carro
                            Console.WriteLine("Carro editado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Preço inválido.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Carro não encontrado.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao editar carro: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("ID inválido.");
            }
        }

        private async Task ListarClientesCadastradosAsync()
        {
            try
            {
                List<Cliente> clientes = await _clienteUC.ListarClientesAsync(); // Método para listar clientes
                if (clientes.Count == 0)
                {
                    Console.WriteLine("Nenhum cliente cadastrado.");
                }
                else
                {
                    foreach (Cliente c in clientes)
                    {
                        Console.WriteLine(c.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar clientes: {ex.Message}");
            }
        }

        private async Task CadastrarProdutoAsync()
        {
            Produto produto = new Produto();
            Console.WriteLine("Digite o nome do produto: ");
            produto.Nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do produto: ");
            while (!double.TryParse(Console.ReadLine(), out double preco))
            {
                Console.WriteLine("Preço inválido, tente novamente: ");
            }
            produto.Preco = preco;

            try
            {
                await _produtoUC.CadastrarProdutoAsync(produto);
                Console.WriteLine("Produto cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar produto: {ex.Message}");
            }
        }

        private async Task ListarProdutosAsync()
        {
            try
            {
                List<Produto> produtos = await _produtoUC.ListarProdutosAsync(); // Método para listar produtos
                if (produtos.Count == 0)
                {
                    Console.WriteLine("Nenhum produto encontrado.");
                }
                else
                {
                    foreach (Produto p in produtos)
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao listar produtos: {ex.Message}");
            }
        }
    }


}

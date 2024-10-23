namespace FrontEnd
{
    public class SistemaBase
    {

        public void ExibirMenuPrincipal()
        {
            int resposta = exibirMenuPrincipal();

            switch (resposta)
            {
                case OPCAO_LISTAR_PRODUTOS:
                    ListarProdutos();
                    break;
                case OPCAO_CADASTRAR_PRODUTO:
                    CadastrarProduto();
                    break;
                case OPCAO_LISTAR_CLIENTES:
                    ListarClientesCadastrados();
                    break;
                case OPCAO_LISTAR_CARROS: // Novo caso para listar carros
                    ListarCarros();
                    break;
                case OPCAO_CANCELAR_COMPRA: // Novo caso para cancelar compra
                    CancelarCompra();
                    break;
                case OPCAO_EDITAR_CARRO: // Novo caso para editar carro
                    EditarCarro();
                    break;
                case OPCAO_CANCELAR:
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
}
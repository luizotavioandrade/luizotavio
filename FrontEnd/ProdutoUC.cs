namespace FrontEnd
{
    internal class ProdutoUC
    {
        private HttpClient cliente;

        public ProdutoUC(HttpClient cliente)
        {
            this.cliente = cliente;
        }

        internal void CadastrarProduto(Produto produto)
        {
            throw new NotImplementedException();
        }

        internal Task CadastrarProdutoAsync(Produto produto)
        {
            throw new NotImplementedException();
        }

        internal List<Produto> ListarProduto()
        {
            throw new NotImplementedException();
        }
    }
}
namespace Core.Entidades
{
    public class Estoque
    {
        public int Id { get; set; }           // Identificador do item de estoque
        public string Modelo { get; set; }     // Nome do modelo do veículo
        public double Preco { get; set; }      // Preço do veículo
        public int Quantidade { get; set; }    // Quantidade disponível em estoque
        public string Marca { get; set; }      // Marca do veículo
        public int Ano { get; set; }           // Ano de fabricação do veículo

        public override string ToString()
        {
            return $"Id: {Id} - Modelo: {Modelo} - Marca: {Marca} - Ano: {Ano} - Preço: {Preco} - Quantidade: {Quantidade}";
        }
    }
}

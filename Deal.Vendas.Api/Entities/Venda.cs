namespace Deal.Vendas.Api.Entities
{
    public class Venda
    {
        public int ID { get; set; }
        public string Nome_Vendedor { get; set; }
        public int Quantidade { get; set; }
        public string Produto { get; set; }
        public string Cidade { get; set; }
    }
}

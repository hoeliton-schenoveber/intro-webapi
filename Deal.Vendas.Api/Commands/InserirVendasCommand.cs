namespace Deal.Vendas.Api.Commands
{
    public class InserirVendasCommand
    {
            public int ID { get; set; } 
            public string Nome_Vendedor { get; set; }
            public int Quantidade { get; set; }
            public string Produto { get; set; }
            public string Cidade { get; set; }

    }
}

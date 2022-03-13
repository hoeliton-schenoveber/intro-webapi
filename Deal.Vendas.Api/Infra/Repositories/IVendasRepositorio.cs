using Deal.Vendas.Api.Commands;
using Deal.Vendas.Api.Entities;

namespace Deal.Vendas.Api.Infra.Repositories
{
    public interface IVendasRepositorio
    {
        Task<List<Venda>> GetAsync();

        Task<Venda> GetAsync(int id);

        Task PostAsync(InserirVendasCommand command);

        Task PutAsync(AtualizarVendasCommand command);
    }
}

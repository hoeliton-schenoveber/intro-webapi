using Dapper;
using Deal.Vendas.Api.Commands;
using Deal.Vendas.Api.Entities;
using Deal.Vendas.Api.Infra.Data;

namespace Deal.Vendas.Api.Infra.Repositories
{
    public class VendasRepositorio : IVendasRepositorio
    {

        private readonly DataContext _context;
        public VendasRepositorio(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Venda>> GetAsync()
        {
            using (var connection = _context.Connection)
            {
                var query = "SELECT * FROM Vendas";
                var result = (await connection.QueryAsync<Venda>(query)).ToList();
                return result;
            }
        }

        public async Task<Venda> GetAsync(int id)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", id);

            using (var connection = _context.Connection)
            {
                var query = "SELECT * FROM Vendas WHERE ID = @ID";
                var result = (await connection.QueryFirstOrDefaultAsync<Venda>(query, parametros));
                return result;
            }
        }

        public async Task PostAsync(InserirVendasCommand command)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", command.ID);
            parametros.Add("@Nome_Vendedor", command.Nome_Vendedor);
            parametros.Add("@Produto", command.Produto);
            parametros.Add("@Quantidade", command.Quantidade);
            parametros.Add("@Cidade", command.Cidade);

            using (var connection = _context.Connection)
            {
                var query = @"INSERT INTO Vendas
                            (ID, Nome_Vendedor, Quantidade, Produto, Cidade)
                            VALUES (@ID, @Nome_Vendedor, @Quantidade, @Produto, @Cidade);";
                var result = await connection.QueryAsync(query, parametros);

            }
        }

        public async Task PutAsync(AtualizarVendasCommand command)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@ID", command.ID);
            parametros.Add("@Quantidade", command.Quantidade);

            using (var connection = _context.Connection)
            {
                var query = @" UPDATE Vendas
                               SET Quantidade = @Quantidade where ID = @ID; ";
                var result = await connection.QueryAsync(query, parametros);

            }
        }
    }
}

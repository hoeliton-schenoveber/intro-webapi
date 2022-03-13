using MySql.Data.MySqlClient;

namespace Deal.Vendas.Api.Infra.Data
{
    public class DataContext : IAsyncDisposable
    {
        public MySqlConnection Connection { get; set; }

        public DataContext(IConfiguration configuration)
        {
            Connection = new MySqlConnection(configuration.GetConnectionString("Default"));
            Connection.Open();
        }

        public async ValueTask DisposeAsync()
        {
            await Connection.CloseAsync();
            await Connection.ClearAllPoolsAsync();
            await Connection.DisposeAsync();
        }
    }
}

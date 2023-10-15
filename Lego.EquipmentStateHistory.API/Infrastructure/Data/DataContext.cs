using Microsoft.Data.Sqlite;
using System.Data;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Data
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = _configuration.GetConnectionString("localDb");
            return new SqliteConnection(connectionString);
        }
    }
}

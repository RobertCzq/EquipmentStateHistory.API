using System.Data;

namespace Lego.EquipmentStateHistory.API.Infrastructure.Data
{
    public interface IDataContext
    {
        IDbConnection CreateConnection();
    }
}

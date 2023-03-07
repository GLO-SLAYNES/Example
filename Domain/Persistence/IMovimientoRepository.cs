using Domain.Model;

namespace Domain.Persistence
{
    public interface IMovimientoRepository : IRepository<Movimiento>
    {
        IEnumerable<Movimiento> GetMovimientoByDateAndClientId(DateTime start, DateTime end, int clientId);
    }
}

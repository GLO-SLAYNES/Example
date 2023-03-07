using Domain.Model;

namespace Domain.Service
{
    public interface IMovimientoService  : IService<Movimiento>
    {
        bool IsMovimientoValidated(string nroCuenta, decimal monto);
        Movimiento? ExecuteMovimiento(string nroCuenta, decimal monto);
        IEnumerable<Movimiento> GetMovimientosByFechaAndClientId(DateTime start, DateTime end, int clientId);
    }
}

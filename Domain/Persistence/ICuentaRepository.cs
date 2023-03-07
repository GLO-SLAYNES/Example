using Domain.Model;

namespace Domain.Persistence
{
    public interface ICuentaRepository : IRepository<Cuenta>
    {
        Cuenta? GetByNroCuenta(string nroCuenta);
    }
}

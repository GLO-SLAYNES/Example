using Domain.Model;

namespace Domain.Service
{
    public interface ICuentaService : IService<Cuenta>
    {
        Cuenta? GetCuentaByNroCuenta(string nroCuenta);
    }
}

using Domain.Model;
using Domain.Persistence;

namespace InfrastructureInMemory.Persistence
{
    public class CuentaRepository : ICuentaRepository
    {
        internal static List<Cuenta> _cuentas = new();
        private static int _id = 0;

        public Cuenta? Delete(int id)
        {
            var cuenta = GetById(id);
            if (cuenta != null)
            {
                cuenta.Id = 0;
                _cuentas.Remove(cuenta);
            }

            return cuenta;
        }

        public Cuenta? GetById(int id)
        {
            return _cuentas.FirstOrDefault(x => x.Id == id);
        }

        public Cuenta? GetByNroCuenta(string nroCuenta)
        {
            return _cuentas.FirstOrDefault(x => x.NroCuenta == nroCuenta);
        }

        public Cuenta? Save(Cuenta entity)
        {
            entity.Id = ++_id;
            entity.Cliente ??= ClienteRepository._clientes.FirstOrDefault(x => x.Id == entity.ClienteId);
            _cuentas.Add(entity);

            return entity;
        }

        public Cuenta? Update(Cuenta entity)
        {
            var cuenta = GetById(entity.Id);
            if (cuenta != null)
            {
                cuenta.ClienteId = entity.ClienteId;
                cuenta.Cliente = ClienteRepository._clientes.FirstOrDefault(x => x.Id == entity.ClienteId);
                cuenta.Tipo = entity.Tipo;
                cuenta.NroCuenta = entity.NroCuenta;
                cuenta.Estado = entity.Estado;
                cuenta.SaldoInicial = entity.SaldoInicial;
            }

            return cuenta;
        }
    }
}

using Domain.Model;
using Domain.Persistence;
using Domain.Service;

namespace Application.Service
{
    public class MovimientoService : IMovimientoService
    {
        private IMovimientoRepository _movimientoRepository;
        private ICuentaRepository _cuentaRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository, ICuentaRepository cuentaRepository)
        {
            _movimientoRepository = movimientoRepository;
            _cuentaRepository = cuentaRepository;
        }

        public Movimiento Create(Movimiento entity)
        {
            var movimiento = _movimientoRepository.Save(entity);

            if (movimiento.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            return movimiento;
        }

        public Movimiento? Read(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            return _movimientoRepository.GetById(id);
        }

        public Movimiento Update(Movimiento entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }

            if (entity == null || entity.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            var movimiento = _movimientoRepository.GetById(entity.Id);

            if (movimiento == null)
            {
                throw new NullReferenceException(nameof(movimiento));
            }

            movimiento.Saldo = movimiento.Saldo;
            movimiento.Valor = movimiento.Valor;
            movimiento.Fecha = entity.Fecha ?? movimiento.Fecha;
            movimiento.Tipo = entity.Tipo ?? movimiento.Tipo;

            return _movimientoRepository.Update(movimiento);
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            _movimientoRepository.Delete(id);
        }

        public bool IsMovimientoValidated(string nroCuenta, decimal monto)
        {
            var cuenta = _cuentaRepository.GetByNroCuenta(nroCuenta);

            if (cuenta == null)
            {
                throw new NullReferenceException(nameof(cuenta));
            }

            return cuenta.SaldoInicial == 0 && monto < 0 ? false : true;
        }

        public Movimiento? ExecuteMovimiento(string nroCuenta, decimal monto)
        {
            var cuenta = _cuentaRepository.GetByNroCuenta(nroCuenta);

            if (cuenta == null)
            {
                throw new NullReferenceException(nameof(cuenta));
            }

            var movimiento = new Movimiento { 
                Cuenta = cuenta,
                CuentaId = cuenta.Id,
                Fecha = DateTime.Now,
                Saldo = cuenta.SaldoInicial,
                Tipo = cuenta.Tipo,
                Valor = monto
            };

            // transaction
            var movimientoResult = _movimientoRepository.Save(movimiento);

            cuenta.SaldoInicial = cuenta.SaldoInicial + monto;

            _cuentaRepository.Update(cuenta);

            return movimientoResult;
        }

        public IEnumerable<Movimiento> GetMovimientosByFechaAndClientId(DateTime start, DateTime end, int clientId)
        {
            return _movimientoRepository.GetMovimientoByDateAndClientId(start, end, clientId);
        }
    }
}

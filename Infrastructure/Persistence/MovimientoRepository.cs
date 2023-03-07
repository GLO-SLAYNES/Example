using Domain.Model;
using Domain.Persistence;

namespace InfrastructureInMemory.Persistence
{
    public class MovimientoRepository : IRepository<Movimiento>
    {
        private static List<Movimiento> _movimientos = new();
        private static int _id = 0;

        public Movimiento? Delete(int id)
        {
            var movimiento = GetById(id);
            if (movimiento != null) 
            {
                movimiento.Id = 0;
                _movimientos.Remove(movimiento);
            }

            return movimiento;
        }

        public Movimiento? GetById(int id)
        {
            return _movimientos.FirstOrDefault(x => x.Id == id);
        }

        public Movimiento? Save(Movimiento entity)
        {
            entity.Id = ++_id;
            entity.Cuenta = CuentaRepository._cuentas.FirstOrDefault(x => x.Id == entity.CuentaId);
            _movimientos.Add(entity);

            return entity;
        }

        public Movimiento? Update(Movimiento entity)
        {
            var movimiento = GetById(entity.Id);
            if (movimiento != null)
            {
                movimiento.CuentaId = entity.CuentaId;
                movimiento.Cuenta = CuentaRepository._cuentas.FirstOrDefault(x => x.Id == entity.CuentaId);
                movimiento.Fecha = entity.Fecha;
                movimiento.Tipo = entity.Tipo;
                movimiento.Saldo = entity.Saldo;
                movimiento.Valor = entity.Valor;
                movimiento.Entidad = entity.Entidad;
            }

            return movimiento;
        }
    }
}

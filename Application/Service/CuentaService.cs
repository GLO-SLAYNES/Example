using Domain.Model;
using Domain.Persistence;
using Domain.Service;

namespace Application.Service
{
    public class CuentaService : IService<Cuenta>
    {
        private IRepository<Cuenta> _repository;

        public CuentaService(IRepository<Cuenta> repository)
        {
            _repository = repository;
        }

        public Cuenta Create(Cuenta entity)
        {
            var cuenta = _repository.Save(entity);

            if (cuenta.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            return cuenta;
        }

        public Cuenta? Read(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            return _repository.GetById(id);
        }

        public Cuenta Update(Cuenta entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }

            if (entity == null || entity.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            var movimiento = _repository.GetById(entity.Id);

            if (movimiento == null)
            {
                throw new NullReferenceException(nameof(movimiento));
            }

            movimiento.NroCuenta = entity.NroCuenta ?? movimiento.NroCuenta;
            movimiento.Tipo = entity.Tipo ?? movimiento.Tipo;
            movimiento.SaldoInicial = entity.SaldoInicial ?? movimiento.SaldoInicial;
            movimiento.Estado = entity.Estado;

            return _repository.Update(movimiento);
        }

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            _repository.Delete(id);
        }
    }
}

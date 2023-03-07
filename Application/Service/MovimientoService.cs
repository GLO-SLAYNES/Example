using Domain.Model;
using Domain.Persistence;
using Domain.Service;

namespace Application.Service
{
    public class MovimientoService : IService<Movimiento>
    {
        private IRepository<Movimiento> _repository;

        public MovimientoService(IRepository<Movimiento> repository)
        {
            _repository = repository;
        }

        public Movimiento Create(Movimiento entity)
        {
            var movimiento = _repository.Save(entity);

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

            return _repository.GetById(id);
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

            var movimiento = _repository.GetById(entity.Id);

            if (movimiento == null)
            {
                throw new NullReferenceException(nameof(movimiento));
            }

            movimiento.Saldo = movimiento.Saldo;
            movimiento.Valor = movimiento.Valor;
            movimiento.Fecha = entity.Fecha ?? movimiento.Fecha;
            movimiento.Tipo = entity.Tipo ?? movimiento.Tipo;

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

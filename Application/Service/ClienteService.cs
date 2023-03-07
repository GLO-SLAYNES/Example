using Domain.Model;
using Domain.Persistence;
using Domain.Service;

namespace Application.Service
{
    public class ClienteService : IService<Cliente>
    {
        private IRepository<Cliente> _repository;

        public ClienteService(IRepository<Cliente> repository)
        {
            _repository = repository;
        }

        public Cliente Create(Cliente entity)
        {
            var cliente = _repository.Save(entity);

            if (cliente.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            return cliente;
        }

        public Cliente? Read(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            return _repository.GetById(id);
        }

        public Cliente Update(Cliente entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }

            if (entity == null || entity.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            var cliente = _repository.GetById(entity.Id);

            if (cliente == null)
            {
                throw new NullReferenceException(nameof(cliente));
            }

            cliente.PersonaId = entity.PersonaId;
            cliente.Estado = entity.Estado;
            cliente.Password = entity.Password ?? cliente.Password;

            return _repository.Update(cliente);
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

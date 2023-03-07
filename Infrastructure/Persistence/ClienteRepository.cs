using Domain.Model;
using Domain.Persistence;

namespace InfrastructureInMemory.Persistence
{
    public class ClienteRepository : IRepository<Cliente>
    {
        internal static List<Cliente> _clientes = new();
        private static int _id = 0;

        public Cliente? Delete(int id)
        {
            var cliente = GetById(id);
            if (cliente != null)
            {
                cliente.Id = 0;
                _clientes.Remove(cliente);
            }

            return cliente;
        }

        public Cliente? GetById(int id)
        {
            return _clientes.FirstOrDefault(x => x.Id == id);
        }

        public Cliente? Save(Cliente entity)
        {
            entity.Id = ++_id;
            entity.Persona ??= PersonaRepository._personas.FirstOrDefault(x => x.Id == entity.PersonaId);
            _clientes.Add(entity);

            return entity;
        }

        public Cliente? Update(Cliente entity)
        {
            var cliente = GetById(entity.Id);
            if (cliente != null)
            {
                cliente.PersonaId = entity.PersonaId;
                cliente.Persona = PersonaRepository._personas.FirstOrDefault(x => x.Id == entity.PersonaId);
                cliente.Estado = entity.Estado;
                cliente.Password = entity.Password;
            }

            return cliente;
        }
    }
}

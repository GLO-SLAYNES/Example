using Domain.Model;
using Domain.Persistence;

namespace InfrastructureInMemory.Persistence
{
    public class PersonaRepository : IRepository<Persona>
    {
        internal static List<Persona> _personas = new();
        private static int _id = 0;

        public Persona? Delete(int id)
        {
            var persona = GetById(id);
            if (persona != null) 
            {
                persona.Id = 0;
                _personas.Remove(persona);
            }

            return persona;
        }

        public Persona? GetById(int id)
        {
            return _personas.FirstOrDefault(x => x.Id == id);
        }

        public Persona? Save(Persona entity)
        {
            entity.Id = ++_id;
            _personas.Add(entity);

            return entity;
        }

        public Persona? Update(Persona entity)
        {
            var persona = GetById(entity.Id);
            if (persona != null) { 
                persona.Nombre = entity.Nombre;
                persona.Edad = entity.Edad;
                persona.Identificacion = entity.Identificacion;
                persona.Direccion = entity.Direccion;
                persona.Genero = entity.Genero;
                persona.Telefono = entity.Telefono;
            }

            return persona;
        }
    }
}
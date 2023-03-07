using Domain.Model;
using Domain.Persistence;
using Domain.Service;

namespace Application.Service
{
    public class PersonaService : IService<Persona>
    {
        private IRepository<Persona> _repository;

        public PersonaService(IRepository<Persona> repository)
        {
            _repository = repository;
        }

        public Persona Create(Persona entity)
        {
            var persona = _repository.Save(entity);

            if (persona.Id == 0) 
            {
                throw new NullReferenceException(nameof(persona.Id));
            }

            return persona;
        }

        public Persona? Read(int id)
        {
            if (id == 0)
            {
                throw new NullReferenceException(nameof(id));
            }

            return _repository.GetById(id);
        }

        public Persona Update(Persona entity)
        {
            if (entity == null)
            {
                throw new NullReferenceException(nameof(entity));
            }

            if (entity == null || entity.Id == 0)
            {
                throw new NullReferenceException(nameof(entity.Id));
            }

            var persona = _repository.GetById(entity.Id);

            if (persona == null)
            {
                throw new NullReferenceException(nameof(persona));
            }

            persona.Nombre = entity.Nombre ?? persona.Nombre;
            persona.Edad = entity.Edad ?? persona.Edad;
            persona.Identificacion = entity.Identificacion ?? persona.Identificacion;
            persona.Direccion = entity.Direccion ?? persona.Direccion;
            persona.Genero = entity.Genero ?? persona.Genero;
            persona.Telefono = entity.Telefono ?? persona.Telefono;

            return _repository.Update(persona);
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
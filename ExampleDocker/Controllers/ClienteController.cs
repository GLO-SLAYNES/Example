using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IService<Cliente> _clienteService;
        private readonly IService<Persona> _personaService;

        public ClienteController(ILogger<ClienteController> logger, IService<Cliente> clienteService, IService<Persona> PersonaService)
        {
            _logger = logger;
            _clienteService = clienteService;
            _personaService = PersonaService;
        }

        [HttpGet(Name = "GetCliente")]
        public ClienteModel? Get(int id)
        {
            var cliente = _clienteService.Read(id);
            var persona = cliente.Persona;

            return new ClienteModel {
                Id = cliente.Id,
                Estado = cliente.Estado,
                Nombre = persona.Nombre,
                Genero = persona.Genero,
                Edad = persona.Edad,
                Identificacion = persona.Identificacion,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
            };
        }

        [HttpPost(Name = "CreateCliente")]
        public ClienteModel? Create(ClienteModel model)
        {
            var persona = _personaService.Create(new Persona { 
                Nombre = model.Nombre,
                Genero = model.Genero,
                Edad = model.Edad,
                Identificacion = model.Identificacion,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
            });

            var cliente = _clienteService.Create(new Cliente { 
                Estado = model.Estado,
                Password = model.Password,
                PersonaId = persona.Id,
            });

            return new ClienteModel
            {
                Id = cliente.Id,
                Estado = cliente.Estado,
                Nombre = persona.Nombre,
                Genero = persona.Genero,
                Edad = persona.Edad,
                Identificacion = persona.Identificacion,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
            };
        }

        [HttpDelete(Name = "DeleteCliente")]
        public void Delete(int id)
        {
            _clienteService.Delete(id);
        }

        [HttpPatch(Name = "EditCliente")]
        public ClienteModel? Edit(ClienteModel model)
        {
            var personaId = _clienteService.Read(model.Id).PersonaId;

            var cliente = _clienteService.Update(new Cliente
            {
                Id = model.Id,
                Estado = model.Estado,
                Password = model.Password,
                PersonaId = personaId,
            });

            var persona = _personaService.Update(new Persona
            {
                Id = personaId,
                Nombre = model.Nombre,
                Genero = model.Genero,
                Edad = model.Edad,
                Identificacion = model.Identificacion,
                Direccion = model.Direccion,
                Telefono = model.Telefono,
            });

            return new ClienteModel
            {
                Id = cliente.Id,
                Estado = cliente.Estado,
                Nombre = persona.Nombre,
                Genero = persona.Genero,
                Edad = persona.Edad,
                Identificacion = persona.Identificacion,
                Direccion = persona.Direccion,
                Telefono = persona.Telefono,
            };
        }
    }
}

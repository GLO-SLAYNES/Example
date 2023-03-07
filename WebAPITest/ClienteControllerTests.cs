using Application.Service;
using Domain.Model;
using Domain.Persistence;
using Microsoft.Extensions.Logging;
using Moq;
using System.Reflection;
using WebAPI.Controllers;
using WebAPI.Model;

namespace WebAPITest
{
    public class ClienteControllerTests
    {
        private Mock<ILogger<ClienteController>> _logger;
        private Mock<IRepository<Cliente>> _clienteRepository;
        private Mock<IRepository<Persona>> _personaRepository;
        private ClienteModel _clienteModel;
        private Persona _mockPersona;
        private Cliente _mockCliente;

        [SetUp]
        public void Setup()
        {
            _logger = new Mock<ILogger<ClienteController>>();
            _clienteRepository = new Mock<IRepository<Cliente>>();
            _personaRepository = new Mock<IRepository<Persona>>();

            _clienteModel = new ClienteModel
            {
                Nombre = "Test",
                Genero = "Test",
                Edad = 19,
                Identificacion = "12345678",
                Direccion = "Dir",
                Telefono = "1234566778",
                Password = "password",
                Estado = true
            };

            _mockPersona = new Persona
            {
                Nombre = _clienteModel.Nombre,
                Genero = _clienteModel.Genero,
                Identificacion = _clienteModel.Identificacion,
                Direccion = _clienteModel.Direccion,
                Telefono = _clienteModel.Telefono,
                Id = 1
            };

            _mockCliente = new Cliente
            {
                Password = _clienteModel.Password,
                Estado = _clienteModel.Estado,
                Id = 1,
                PersonaId = _clienteModel.Id,
                Persona = _mockPersona
            };
        }

        [Test]
        public void CreateTest()
        {
            _clienteRepository.Setup(x => x.Save(It.IsAny<Cliente>())).Returns(() => _mockCliente);
            _personaRepository.Setup(x => x.Save(It.IsAny<Persona>())).Returns(() => _mockPersona);

            var clienteService = new ClienteService(_clienteRepository.Object);
            var personaService = new PersonaService(_personaRepository.Object);
            var controller = new ClienteController(_logger.Object, clienteService, personaService);
            var result = controller.Create(_clienteModel);
            
            Assert.True(result.Id > 0);
        }
    }
}
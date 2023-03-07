using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly IService<Cuenta> _service;

        public CuentaController(ILogger<CuentaController> logger, IService<Cuenta> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetCuenta")]
        public Cuenta? Get(int id)
        {
            return _service.Read(id);
        }

        [HttpPost(Name = "CreateCuenta")]
        public Cuenta? Create(Cuenta Cuenta)
        {
            return _service.Create(Cuenta);
        }

        [HttpDelete(Name = "DeleteCuenta")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPatch(Name = "EditCuenta")]
        public Cuenta? Edit(Cuenta Cuenta)
        {
            return _service.Update(Cuenta);
        }

    }
}

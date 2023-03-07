using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private readonly ILogger<CuentaController> _logger;
        private readonly ICuentaService _service;

        public CuentaController(ILogger<CuentaController> logger, ICuentaService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetCuenta")]
        public CuentaModel Get(int id)
        {
            var cuenta = _service.Read(id);
            return new CuentaModel {
                NroCuenta = cuenta.NroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                ClienteId = cuenta.ClienteId,
                Id = cuenta.Id
            };
        }

        [HttpPost(Name = "CreateCuenta")]
        public CuentaModel Create(CuentaModel model)
        {
            var cuenta = _service.Create(new Cuenta { 
                NroCuenta = model.NroCuenta,
                Tipo = model.Tipo,
                SaldoInicial = model.SaldoInicial,
                Estado = model.Estado,
                ClienteId = model.ClienteId
            });

            return new CuentaModel 
            {
                NroCuenta = cuenta.NroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                ClienteId = cuenta.ClienteId,
                Id = cuenta.Id
            };
        }

        [HttpDelete(Name = "DeleteCuenta")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPatch(Name = "EditCuenta")]
        public CuentaModel Edit(CuentaModel model)
        {
            var cuenta = _service.Update(new Cuenta
            {
                Id = model.Id,
                NroCuenta = model.NroCuenta,
                Tipo = model.Tipo,
                SaldoInicial = model.SaldoInicial,
                Estado = model.Estado,
                ClienteId = model.ClienteId
            });

            return new CuentaModel
            {
                NroCuenta = cuenta.NroCuenta,
                Tipo = cuenta.Tipo,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = model.Estado,
                ClienteId = model.ClienteId,
                Id = model.Id
            };
        }

    }
}

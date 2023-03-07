using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly ILogger<MovimientoController> _logger;
        private readonly IMovimientoService _service;

        public MovimientoController(ILogger<MovimientoController> logger, IMovimientoService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpDelete(Name = "DeleteMovimiento")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPatch(Name = "EditMovimiento")]
        public Movimiento? Edit(MovimientoModel model)
        {
            return _service.Update(new Movimiento
            {
                Id = model.Id,
                CuentaId = model.CuentaId,
                Fecha = model.Fecha,
                Saldo = model.Saldo,
                Tipo = model.Tipo,
                Valor = model.Valor
            });
        }

        [HttpGet(Name = "GetReport")]
        public IEnumerable<MovimientoReportModel> Report(DateTime start, DateTime end, int clientId)
        {
            var movimientos = _service.GetMovimientosByFechaAndClientId(start, end, clientId);
            return movimientos.Select(x =>
                new MovimientoReportModel
                {
                    Fecha = x.Fecha,
                    Cliente = x.Cuenta.Cliente.Persona.Nombre,
                    NroCuenta = x.Cuenta.NroCuenta,
                    Tipo = x.Cuenta.Tipo,
                    Estado = x.Cuenta.Estado,
                    Movimiento = x.Valor,
                    SaldoDisponible = x.Cuenta.SaldoInicial
                });
        }

        [HttpPost(Name = "ExecMovimiento")]
        public MovimientoTransactionModel ExecMovimientoTransaction(MovimientoTransactionModel model)
        {
            var response = new MovimientoTransactionModel
            {
                NroCuenta = model.NroCuenta,
                Valor = model.Valor,
            };

            if (!_service.IsMovimientoValidated(model.NroCuenta, model.Valor))
            {
                response.Mensaje = "Saldo no disponible";
                return response;
            }

            var movimiento = _service.ExecuteMovimiento(model.NroCuenta, model.Valor);

            if (movimiento == null)
            {
                response.Mensaje = "Error en la transacción";
                return response;
            }

            response.Mensaje = $"Se creó el movimiento {movimiento.Id}";
            return response;
        }
    }
}

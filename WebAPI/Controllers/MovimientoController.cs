using Domain.Model;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly ILogger<MovimientoController> _logger;
        private readonly IService<Movimiento> _service;

        public MovimientoController(ILogger<MovimientoController> logger, IService<Movimiento> service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet(Name = "GetMovimiento")]
        public Movimiento? Get(int id)
        {
            return _service.Read(id);
        }

        [HttpPost(Name = "CreateMovimiento")]
        public Movimiento? Create(Movimiento Movimiento)
        {
            return _service.Create(Movimiento);
        }

        [HttpDelete(Name = "DeleteMovimiento")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }

        [HttpPatch(Name = "EditMovimiento")]
        public Movimiento? Edit(Movimiento Movimiento)
        {
            return _service.Update(Movimiento);
        }
    }
}

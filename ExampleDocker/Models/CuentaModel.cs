using Domain.Model;

namespace WebAPI.Model
{
    public class CuentaModel
    {
        public int Id { get; set; }
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }
    }
}

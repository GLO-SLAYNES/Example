namespace Domain.Model
{
    public class Cuenta
    {
        public int Id { get; set; }
        public string NroCuenta { get; set; }
        public string Tipo { get; set; }
        public string SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
    }
}
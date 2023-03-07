namespace Domain.Model
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public DateTime? Fecha { get; set; }
        public string Tipo { get; set; }
        public string Valor { get; set; }
        public string Saldo { get; set; }
        public Cuenta? Cuenta { get; set; }
        public int CuentaId { get; set; }
    }
}
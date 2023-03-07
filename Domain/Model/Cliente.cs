namespace Domain.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }
        public Persona? Persona { get; set; }
        public int PersonaId { get; set; }
    }
}
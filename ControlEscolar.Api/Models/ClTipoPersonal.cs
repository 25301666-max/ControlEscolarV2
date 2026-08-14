namespace ControlEscolar.Api.Models
{
    public class TipoPersonal
    {
        public int IdTipo { get; set; }

        public string Personal { get; set; } = string.Empty;

        public ICollection<Personal> Personales { get; set; }
            = new List<Personal>();
    }
}
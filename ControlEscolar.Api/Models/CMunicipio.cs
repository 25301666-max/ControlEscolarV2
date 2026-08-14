namespace ControlEscolar.Api.Models
{
    public class Municipio
    {
        public int IdMunicipio { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int IdEstado { get; set; }

        public Estado Estado { get; set; } = new Estado();

        public ICollection<Localidad> Localidades { get; set; }
            = new List<Localidad>();

        public ICollection<DatosPersonales> Personas { get; set; }
            = new List<DatosPersonales>();

        public ICollection<DatosEscuela> Escuelas { get; set; }
            = new List<DatosEscuela>();
    }
}

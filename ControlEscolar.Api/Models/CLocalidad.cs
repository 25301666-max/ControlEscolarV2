namespace ControlEscolar.Api.Models
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int IdMunicipio { get; set; }

        public Municipio Municipio { get; set; } = new Municipio();

        public ICollection<DatosPersonales> Personas { get; set; }
            = new List<DatosPersonales>();

        public ICollection<DatosEscuela> Escuelas { get; set; }
            = new List<DatosEscuela>();
    }
}

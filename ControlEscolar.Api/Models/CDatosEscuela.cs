namespace ControlEscolar.Api.Models
{
    public class DatosEscuela
    {
        public string CCT { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Calle { get; set; } = string.Empty;

        public string NumE { get; set; } = string.Empty;

        public string NumI { get; set; } = string.Empty;

        public int IdLocalidad { get; set; }

        public int IdMunicipio { get; set; }

        public int IdEstado { get; set; }

        public string CP { get; set; } = string.Empty;

        public Localidad Localidad { get; set; } = new Localidad();

        public Municipio Municipio { get; set; } = new Municipio();

        public Estado Estado { get; set; } = new Estado();
    }
}

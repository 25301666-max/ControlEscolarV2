namespace ControlEscolar.Api.Models
{
    public class Estado
    {
        public int IdEstado { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public ICollection<Municipio> Municipios { get; set; }
            = new List<Municipio>();

        public ICollection<DatosPersonales> Personas { get; set; }
            = new List<DatosPersonales>();

        public ICollection<DatosEscuela> Escuelas { get; set; }
            = new List<DatosEscuela>();
    }
}

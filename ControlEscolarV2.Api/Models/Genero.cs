using System.Collections.Generic;

namespace ControlEscolarV2.Api.Models
{
    public class Genero
    {
        public int IdGenero { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public ICollection<DatosPersonales> Personas { get; set; } = new List<DatosPersonales>();
    }
}

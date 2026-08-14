using System.Collections.Generic;

namespace ControlEscolarV2.Api.Models;

public class Estado
{
    public int IdEstado { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public ICollection<Municipio> Localidades { get; set; } = new List<Municipio>();
}
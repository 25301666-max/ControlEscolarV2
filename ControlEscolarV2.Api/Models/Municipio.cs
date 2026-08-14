using ControlEscolarV2.Api.Models;

namespace ControlEscolar.Api.Models;

public class Municipio
{
    public int IdMunicipio { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public int IdEstado { get; set; }

    public Estado Estado { get; set; } = null!;

    public ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
}

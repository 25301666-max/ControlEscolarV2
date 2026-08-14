using ControlEscolarV2.Api.Models;
using System.Collections.Generic;

namespace ControlEscolar.Api.Models;

public class TipoPersonal
{
    public int IdTipoPersonal { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public ICollection<Personal> Personal { get; set; } = new List<Personal>();
}

using ControlEscolarV2.Api.Models;
using System;

namespace ControlEscolar.Api.Models;

public class DatosPersonales
{
    public int IdPersona { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string ApellidoPaterno { get; set; } = string.Empty;

    public string ApellidoMaterno { get; set; } = string.Empty;

    public DateTime FechaNacimiento { get; set; }

    public int IdGenero { get; set; }

    public Genero Genero { get; set; } = null!;
}

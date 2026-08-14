namespace ControlEscolar.Api.Models;

public class DatosEscuela
{
    public int IdDatosEscuela { get; set; }

    public string Matricula { get; set; } = string.Empty;

    public int IdPersona { get; set; }

    public DatosPersonales Persona { get; set; } = null!;
}

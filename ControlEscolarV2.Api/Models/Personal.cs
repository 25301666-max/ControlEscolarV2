namespace ControlEscolar.Api.Models;

public class Personal
{
    public int IdPersonal { get; set; }

    public string NumeroEmpleado { get; set; } = string.Empty;

    public int IdPersona { get; set; }

    public DatosPersonales Persona { get; set; } = null!;

    public int IdTipoPersonal { get; set; }

    public TipoPersonal TipoPersonal { get; set; } = null!;
}
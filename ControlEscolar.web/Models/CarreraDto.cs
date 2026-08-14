namespace ControlEscolar.Web.Models;

public class CarreraDto
{
    public int IdCarrera { get; set; }

    public string NombreCarrera { get; set; } = string.Empty;

    public bool? Estatus { get; set; }
}
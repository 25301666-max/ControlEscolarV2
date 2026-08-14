namespace ControlEscolar.Api.Models
{
    public class Personal
    {
        public int IdPersonal { get; set; }

        public int IdDatosP { get; set; }

        public int IdTipo { get; set; }

        public string ClaveEmp { get; set; } = string.Empty;

        public bool Status { get; set; } = true;

        public DatosPersonales DatosPersonales { get; set; } = new DatosPersonales();

        public TipoPersonal TipoPersonal { get; set; } = new TipoPersonal();
    }
}

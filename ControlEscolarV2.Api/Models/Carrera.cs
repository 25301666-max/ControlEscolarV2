using System.Collections.Generic;

namespace ControlEscolarV2.Api.Models
    {
        public class Carrera
        {
            public int IdCarrera { get; set; }

            public string Nombre { get; set; } = string.Empty;

            public ICollection<TbAlumnos> Alumnos { get; set; } = new List<TbAlumnos>();
        }
    }
}
}

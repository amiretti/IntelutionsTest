using System;

namespace IntelutionsTest.Data.Model
{
    public class PermisoModel
    {
        public int Id { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellidos { get; set; }
        public int TipoPermisoId { get; set; }
        public string TipoPermiso { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}

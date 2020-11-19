using System;

namespace IntelutionsTest.Data.ModelDB
{
    public class Permiso
    {
        public int Id { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellidos { get; set; }
        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }
        
        public virtual TipoPermiso TipoPermiso { get; set; }
    }

    public class NewPermiso
    {
        public int Id { get; set; }
        public string EmpleadoNombre { get; set; }
        public string EmpleadoApellidos { get; set; }
        public int TipoPermisoId { get; set; }
        public DateTime FechaPermiso { get; set; }
    }
}

using System.Collections.Generic;

namespace IntelutionsTest.Data.ModelDB
{
    public class TipoPermiso
    {
        public TipoPermiso()
        {
            Permisos = new List<Permiso>();
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Permiso> Permisos { get; set; }
    }
}

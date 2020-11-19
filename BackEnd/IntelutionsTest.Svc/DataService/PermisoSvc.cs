using IntelutionsTest.Data.ModelDB;
using IntelutionsTest.Svc.GenericDataService;
using System.Collections.Generic;
using System.Linq;

namespace IntelutionsTest.Svc.DataService
{
    public class PermisoSvc : GenericSvc<Permiso>, IPermisoSvc
    {
        public Permiso Save(Permiso x)
        {
            if (x.Id == 0)
            {
                var newPermiso = new Permiso()
                {
                    EmpleadoNombre = x.EmpleadoNombre,
                    EmpleadoApellidos = x.EmpleadoApellidos,
                    TipoPermisoId = x.TipoPermisoId,
                    FechaPermiso = x.FechaPermiso
                };

                return CreateEntity(newPermiso);
            }
            else
            {
                var db = Load(x.Id);

                db.EmpleadoNombre = x.EmpleadoNombre ?? db.EmpleadoNombre;
                db.EmpleadoApellidos = x.EmpleadoApellidos ?? db.EmpleadoApellidos;
                db.TipoPermisoId = x.TipoPermisoId != null ? x.TipoPermisoId : db.TipoPermisoId;
                db.FechaPermiso = x.FechaPermiso.Date != null ? x.FechaPermiso.Date : db.FechaPermiso.Date;

                return UpdateEntity(db);
            }
        }

        public List<Permiso> LoadAllLicenses()
        {
            return LoadAll().OrderByDescending(x => x.FechaPermiso).ToList();
        }

        public Permiso GetById(int id)
        {
            return Load(id);
        }

        public void Delete(int id)
        {
            DeleteById(id);
        }
    }
}

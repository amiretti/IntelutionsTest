using IntelutionsTest.Data.ModelDB;
using IntelutionsTest.Svc.GenericDataService;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace IntelutionsTest.Svc.DataService
{
    public class TipoPermisoSvc : GenericSvc<TipoPermiso>, ITipoPermisoSvc
    {
        public TipoPermiso GetById(int id)
        {
            return Load(id);
        }

        public List<TipoPermiso> LoadAllTypes()
        {
            return LoadAll().OrderBy(x => x.Descripcion).ToList();
        }
    }
}

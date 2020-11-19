using IntelutionsTest.Data.ModelDB;
using System.Collections.Generic;

namespace IntelutionsTest.Svc.DataService
{
    public interface ITipoPermisoSvc
    {
        List<TipoPermiso> LoadAllTypes();
        TipoPermiso GetById(int id);
    }
}

using IntelutionsTest.Data.ModelDB;
using System.Collections.Generic;

namespace IntelutionsTest.Svc.DataService
{
    public interface IPermisoSvc
    {
        public Permiso Save(Permiso x);
        public void Delete(int id);
        public List<Permiso> LoadAllLicenses();
        public Permiso GetById(int id);
    }
}

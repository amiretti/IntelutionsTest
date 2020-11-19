using IntelutionsTest.Data.Model;
using IntelutionsTest.Data.ModelDB;
using IntelutionsTest.Svc.DataService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IntelutionsTest.Api.Core
{
    public class IntelutionsTestBaseController : ControllerBase, IDisposable
    {
      
        #region Svc
        /// <summary>
        /// Referencia a UserSvc
        /// </summary>
        protected PermisoSvc permisoSvc = null;
        protected TipoPermisoSvc tipoPermisoSvc = null;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public IntelutionsTestBaseController()
        {
            permisoSvc = new PermisoSvc();
            tipoPermisoSvc = new TipoPermisoSvc();
        }

        #region Mappers
        protected List<TipoPermisoModel> MapToApp(List<TipoPermiso> listTiposPermisos) {
            List<TipoPermisoModel> response = new List<TipoPermisoModel>();
            foreach (var tipoPermiso in listTiposPermisos)
                response.Add(MapToApp(tipoPermiso));

            return response;
        }
        protected TipoPermisoModel MapToApp(TipoPermiso permiso)
        {
            return new TipoPermisoModel()
            {
                Id = permiso.Id,
                Descripcion = permiso.Descripcion
            };
        }

        protected List<PermisoModel> MapToApp(List<Permiso> listPermisos)
        {
            List<PermisoModel> response = new List<PermisoModel>();
            foreach (var permiso in listPermisos)
                response.Add(MapToApp(permiso));

            return response;
        }
        protected PermisoModel MapToApp(Permiso permiso)
        {
            return new PermisoModel()
            {
                Id = permiso.Id,
                EmpleadoApellidos = permiso.EmpleadoApellidos,
                EmpleadoNombre = permiso.EmpleadoNombre,
                FechaPermiso = permiso.FechaPermiso,
                TipoPermiso = tipoPermisoSvc.GetById(permiso.TipoPermisoId).Descripcion
            };
        }
        protected Permiso MapToDB(NewPermiso model)
        {
            return new Permiso()
            {
                Id = model.Id,
                EmpleadoNombre = model.EmpleadoNombre,
                EmpleadoApellidos = model.EmpleadoApellidos,
                FechaPermiso = model.FechaPermiso
                //,
                //TipoPermisoId = model.TipoPermisoId
            };
        } 

        #endregion

        public void Dispose()
        {
            permisoSvc = null;
            tipoPermisoSvc = null;
        }
    }
}
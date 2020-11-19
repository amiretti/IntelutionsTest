using IntelutionsTest.Api.Core;
using IntelutionsTest.Data.Model;
using IntelutionsTest.Data.ModelDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntelutionsTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisoController : IntelutionsTestBaseController
    {
        /// <summary>
        /// Get a list of licenses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(MapToApp(permisoSvc.LoadAllLicenses()));
        }

        /// <summary>
        /// Get a license by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = permisoSvc.GetById(id);
                if (response != null)
                    return Ok(MapToApp(response));
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Create a license
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Permiso model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(model);

                var db = permisoSvc.Save(model);
                return Ok(db);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete a license by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                permisoSvc.DeleteById(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

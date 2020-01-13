using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebHost.Models;

namespace WebHost.Controllers
{
    [RoutePrefix("Equipments")]
    public class EquipmentController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult getAll()
        {
            return this.Ok(new List<EquipmentModel>()
            {
                new EquipmentModel(1, "As 3245"),
                new EquipmentModel(2, "Tank 2")
            });
        }

        [HttpGet]
        [Route("GetByOid/{oid:int}")]
        public IHttpActionResult getByOid(long oid)
        {
            return this.Ok(new EquipmentModel(oid, "Tank info"));
        }
    }
}
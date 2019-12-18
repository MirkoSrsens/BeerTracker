using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebHost.Models;

namespace WebHost.Controllers
{
    [RoutePrefix("ProductionResponse")]
    public class ProductionSegmentResponseController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult getAll()
        {
            return this.Ok(new List<ProductionResponseModel>()
            {
                new ProductionResponseModel(1, DateTime.Now),
                new ProductionResponseModel(2, new DateTime())
            });
        }

        [HttpGet]
        [Route("GetByOid/{oid:int}")]
        public IHttpActionResult getByOid(long oid)
        {
            return this.Ok(new ProductionResponseModel(oid, DateTime.Now));
        }
    }
}
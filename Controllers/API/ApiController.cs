using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZOPE.Controllers.API
{

    [ApiController]
    [Route("api/[controller]")]
    public class APIconteroller : ControllerBase
    {
        [HttpGet]
        public ActionResult Get(){
            string[]x = {"Get","laith","Mmo2ze","Fuck off"};
            return Ok(x);
        }        [HttpPost]
        public ActionResult Post(){
            string[]x = {"Pst","laith","Mmo2ze","Fuck off"};
            return Ok(x);
        }
    }
}
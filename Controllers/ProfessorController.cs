using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace SmartSchool_WebApi.Controllers
{
     [ApiController]
     [Route("api/[controller]")]

        public class ProfessorController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
          return Ok("jair");
        }

    }    
}
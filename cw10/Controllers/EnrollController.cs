using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw10.DTO;
using cw10.Model;
using cw10.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers
{
    [Route("api/enrollments")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly IDbService service;

        public EnrollController(IDbService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("promote")]
        public IActionResult Promote(PromoteDTO req)
        {
            return service.promote(req);
        }
        [HttpPost]
        [Route("enroll")]
        public IActionResult EnrollStudent(EnrollStudentDTO req)
        {
            return service.enrollStudent(req);
        }
    }
}
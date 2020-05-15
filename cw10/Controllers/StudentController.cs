using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw10.Model;
using cw10.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw10.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IDbService service;
        public StudentController(IDbService dbService)
        {
            service = dbService;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = service.getStudents();
            return Ok(students);
        }
        [HttpPost]
        [Route("modify")]
        public IActionResult Modify([FromBody] Student student)
        {
            if (service.modifyStudent(student)) return Ok();
            else return BadRequest();

        }
        [HttpDelete]
        [Route("delete/{index}")]
        public IActionResult Delete([FromRoute] string index)
        {
            if (service.removeStudent(index)) return Ok();
            else return BadRequest();
        }
    }

}
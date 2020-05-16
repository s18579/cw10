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
        public StudentController(IDbService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = service.getStudents();
            return Ok(students);
        }
        [HttpPost]
        [Route("modify")]
        public IActionResult Modify(Student student)
        {
            var result = service.modifyStudent(student);
            return Ok(result);

        }
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(Student student)
        {
            var result = service.removeStudent(student);
            if (result == null) return BadRequest("Nie ma takiego studenta");
            return Ok("Student usuniety");
        }
    }

}
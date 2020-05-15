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
        [HttpPost]
        [Route("enroll")]
        public IActionResult EnrollStudent([FromBody]EnrollStudentDTO req, [FromServices]IDbService dbService)
        {
            Student studentToEnroll = new Student
            {
                IndexNumber = req.IndexNumber,
                LastName = req.LastName,
                FirstName = req.FirstName,
                BirthDate = req.BirthDate
            };

            Enrollment tmp = dbService.enrollStudent(studentToEnroll, req.StudyName);
            if (tmp == null) return BadRequest();

            EnrollStudentDTO2 response = new EnrollStudentDTO2
            {
                Semester = tmp.Semester,
                IdStudy = tmp.IdStudy,
                StartDate = tmp.StartDate,
                IdEnrollment = tmp.IdEnrollment
            };
            return Ok(response);
        }

        [HttpPost]
        [Route("promotions")]
        public IActionResult Promote([FromBody] PromoteDTO req, [FromServices] IDbService dbService)
        {
            var enroll = dbService.promote(req.StudiesId, req.Semester);
            if (enroll == null) return BadRequest();
            else
            {
                var response = new PromoteDTO2
                {
                    Semester = enroll.Semester,
                    IdStudy = enroll.IdStudy,
                    StartDate = enroll.StartDate,
                    IdEnrollment = enroll.IdEnrollment
                };
                return Ok(response);
            }
        }


    }
}
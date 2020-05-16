using cw10.DTO;
using cw10.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Service
{
    public interface IDbService
    {
        public string getStudents();
        public Student modifyStudent(Student student);
        public Student removeStudent(Student student);
        public IActionResult enrollStudent(EnrollStudentDTO req);
        public IActionResult promote(PromoteDTO req);
    }
}
using cw10.Model;
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
        public Enrollment enrollStudent(Student studentToEnroll, string studiesName);
        public Enrollment promote(int id, int semester);

       
    }
}

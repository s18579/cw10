using cw10.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Service
{
    public interface IDbService
    {
        public Enrollment enrollStudent(Student studentToEnroll, string studiesName);

        public Enrollment promote(int id, int semester);

        public string getStudents();

        public bool modifyStudent(Student student);

        public bool removeStudent(string index);
    }
}

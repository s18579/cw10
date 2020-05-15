using cw10.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Service
{
    public class SqlServerDbService : IDbService
    {
        private ModelContext context;

        public SqlServerDbService([FromServices] DbContext dbContext)
        {
            this.context = (ModelContext) dbContext;
        }

        public Enrollment enrollStudent(Student student, string nameOfStudies)
        {
            if (!context.Study.Any(s => s.Name.Equals(nameOfStudies))) return null;
            if (context.Student.Any(s => s.IndexNumber.Equals(student.IndexNumber))) return null;
            Student addStudent = new Student
            {
                IndexNumber = student.IndexNumber,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                FirstName = student.FirstName,
                IdEnrollment = 1
            };
            context.Student.Add(addStudent);
            context.SaveChanges();
            int idStudy = context.Study.Single(s => s.Name.Equals(nameOfStudies)).IdStudy;
            int idEnrollment = context.Enrollment.Where(e => e.Semester == 1 && e.IdStudy == idStudy)
                .OrderByDescending(e => e.StartDate).First().IdEnrollment;
            if (idEnrollment == 0)
            {
                idEnrollment = context.Enrollment.Max(e => e.IdEnrollment) + 1;
                Enrollment newEnrollment = new Enrollment
                {
                    IdEnrollment = idEnrollment,
                    Semester = 1,
                    IdStudy = idStudy,
                    StartDate = DateTime.Now
                };
                context.Enrollment.Add(newEnrollment);
                context.SaveChanges();
            }
            addStudent.IdEnrollment = idEnrollment;
            context.SaveChanges();
            var resp = context.Enrollment.Single(e => e.IdEnrollment == idEnrollment);
            return resp;
        }

        public Enrollment promote(int id, int semester)
        {
            try
            {
                var studies = context.Study.Single(s => s.IdStudy == id);
                var oldEnroll = context.Enrollment.Single(e => e.IdStudy == studies.IdStudy && e.Semester == semester);
                var newEnroll = context.Enrollment.SingleOrDefault(e => e.IdStudy == studies.IdStudy && e.Semester == semester + 1);
                var updateStudents = context.Student.Where(s => s.IdEnrollment == oldEnroll.IdEnrollment).ToList();
                if (newEnroll == null)
                {
                    var newId = context.Enrollment.Max(e => e.IdEnrollment) + 1;
                    newEnroll = new Enrollment
                    {
                        IdEnrollment = newId,
                        Semester = semester + 1,
                        IdStudy = studies.IdStudy,
                        StartDate = DateTime.Now
                    };
                    context.Enrollment.Add(newEnroll);
                    context.SaveChanges();
                }
                foreach (Student student in updateStudents) student.IdEnrollment = newEnroll.IdEnrollment;
                context.SaveChanges();
                return newEnroll;
            }
            catch (Exception)
            { 
                return null;
            }
        }

        public string getStudents()
        {
            String tmp = "";
            var students = context.Student.ToList();
            foreach (var student in students) tmp += student.IndexNumber+" "+student.FirstName+" "+student.LastName+"\n";
            return tmp;
        }

        public bool modifyStudent(Student student)
        {
            try
            {
                var tmp = context.Student.Single(s => s.IndexNumber.Equals(student.IndexNumber));
                if (tmp.FirstName != null) student.FirstName = tmp.FirstName;
                if (tmp.BirthDate != null) student.BirthDate = tmp.BirthDate;
                if (tmp.LastName != null) student.LastName = tmp.LastName;
                if (tmp.IdEnrollment != 0) student.IdEnrollment = tmp.IdEnrollment;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool removeStudent(string index)
        {
            try
            {
                var student = context.Student.Single(s => s.IndexNumber.Equals(index));
                context.Student.Remove(student);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

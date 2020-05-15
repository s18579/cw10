using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Model
{
    public partial class Enrollment
    {
        public int IdEnrollment { get; set; }
        public int Semester { get; set; }
        public int IdStudy { get; set; }
        public DateTime StartDate { get; set; }
        public virtual Study Nav { get; set; }
        public virtual ICollection<Student> StudentList { get; set; }
        public Enrollment()
        {
            StudentList = new HashSet<Student>();
        }
    }
}

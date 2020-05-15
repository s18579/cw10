using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.Model
{
    public partial class Study
    {

        public int IdStudy { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Enrollment> EnrollmentList { get; set; }
        public Study()
        {
            EnrollmentList = new HashSet<Enrollment>();
        }
    }
}

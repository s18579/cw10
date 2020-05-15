using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cw10.DTO
{
    public class PromoteDTO
    {
        [Required]
        public int StudiesId { get; set; }
        [Required]
        public int Semester { get; set; }
    }
}

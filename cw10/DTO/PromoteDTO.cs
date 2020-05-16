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
        public string studies { get; set; }
        [Required]
        public int semester { get; set; }
    }
}

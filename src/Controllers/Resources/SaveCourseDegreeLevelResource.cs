using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Controllers.Resources
{
    public class SaveCourseDegreeLevelResource
    {
        public int Id { get; set; }

        [Required]
        public char DegreeLevelCode { get; set; }

        [Required]
        [StringLength(15)]
        public string DegreeLevelName { get; set; }

    }
}

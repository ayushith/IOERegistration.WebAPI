using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Controllers.Resources
{
    public class CourseDegreeLevelQueryResource
    {
        public string Name { get; set; }

        public string SortBy { get; set; }

        public bool IsSortAscending { get; set; }

        public int Page { get; set; }

        public byte PageSize { get; set; }
    }
}

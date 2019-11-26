using AutoMapper;
using IOERegistration.WebAPI.Controllers.Resources;
using IOERegistration.WebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDegreeLevel, KeyValuePairResource>()
                .ForMember(k => k.Name, opt => opt.MapFrom(c => c.DegreeLevelName));

            CreateMap<CourseDegreeLevelQueryResource, CourseDegreeLevelQuery>();

            CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

            CreateMap<SaveCourseDegreeLevelResource, CourseDegreeLevel>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}

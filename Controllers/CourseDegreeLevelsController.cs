using AutoMapper;
using IOERegistration.WebAPI.Controllers.Resources;
using IOERegistration.WebAPI.Core;
using IOERegistration.WebAPI.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class CourseDegreeLevelsController : ControllerBase    
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICourseDegreeLevelRepository repository;

        public CourseDegreeLevelsController(IMapper mapper, IUnitOfWork unitOfWork, ICourseDegreeLevelRepository repository)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<QueryResultResource<KeyValuePairResource>> GetCourseDegreeLevels(CourseDegreeLevelQueryResource filterResource)
        {
            var filter = mapper.Map<CourseDegreeLevelQueryResource, CourseDegreeLevelQuery>(filterResource);

            var queryResult = await repository.GetCourseDegreeLevels(filter);

            return mapper.Map<QueryResult<CourseDegreeLevel>, QueryResultResource<KeyValuePairResource>>(queryResult);
        }
    }
}

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

        [HttpPost]
        public async Task<IActionResult> CreateCourseDegreeLevel([FromBody]SaveCourseDegreeLevelResource courseDegreeLevelResource )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var courseDegreeLevel = mapper.Map<SaveCourseDegreeLevelResource, CourseDegreeLevel>(courseDegreeLevelResource);

            repository.Add(courseDegreeLevel);

            await unitOfWork.CompleteAsync();

            courseDegreeLevel = await repository.GetCourseDegreeLevel(courseDegreeLevel.Id);

            var result = mapper.Map<CourseDegreeLevel, KeyValuePairResource>(courseDegreeLevel);

            return Ok(result);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseDegreeLevel(int id, [FromBody]SaveCourseDegreeLevelResource courseDegreeLevelResource)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var courseDegreeLevel = await repository.GetCourseDegreeLevel(id);

            if (courseDegreeLevel == null)
                return NotFound();

            mapper.Map<SaveCourseDegreeLevelResource, CourseDegreeLevel>(courseDegreeLevelResource, courseDegreeLevel);

            await unitOfWork.CompleteAsync();

            courseDegreeLevel = await repository.GetCourseDegreeLevel(courseDegreeLevel.Id);

            var result = mapper.Map<CourseDegreeLevel, KeyValuePairResource>(courseDegreeLevel);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseDegreeLevel(int id)
        {
            var courseDegreeLevel = await repository.GetCourseDegreeLevel(id);

            if (courseDegreeLevel == null)
                return NotFound();

            repository.Remove(courseDegreeLevel);

            await unitOfWork.CompleteAsync();

            return Ok(id);
        }

        [HttpGet]
        public async Task<QueryResultResource<KeyValuePairResource>> GetCourseDegreeLevels(CourseDegreeLevelQueryResource filterResource)
        {
            var filter = mapper.Map<CourseDegreeLevelQueryResource, CourseDegreeLevelQuery>(filterResource);

            var queryResult = await repository.GetCourseDegreeLevels(filter);

            return mapper.Map<QueryResult<CourseDegreeLevel>, QueryResultResource<KeyValuePairResource>>(queryResult);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseDegreeLevel(int id)
        {
            var courseDegreeLevel = await repository.GetCourseDegreeLevel(id);

            if (courseDegreeLevel == null)
                return NotFound();

            var result = mapper.Map<CourseDegreeLevel, KeyValuePairResource>(courseDegreeLevel);

            return Ok(result);

        }
    }
}

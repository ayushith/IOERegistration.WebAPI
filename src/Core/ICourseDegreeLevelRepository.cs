using IOERegistration.WebAPI.Core.Models;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Core
{
    public interface ICourseDegreeLevelRepository
    {
        void Add(CourseDegreeLevel courseDegreeLevel);

        Task<CourseDegreeLevel> GetCourseDegreeLevel(int id);

        void Remove(CourseDegreeLevel courseDegreeLevel);

        Task<QueryResult<CourseDegreeLevel>> GetCourseDegreeLevels(CourseDegreeLevelQuery filter);
    }
}

using IOERegistration.WebAPI.Core;
using IOERegistration.WebAPI.Core.Models;
using IOERegistration.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IOERegistration.WebAPI.Persistence
{
    public class CourseDegreeLevelRepository : ICourseDegreeLevelRepository
    {
        private readonly IOEDbContext context;

        public CourseDegreeLevelRepository(IOEDbContext context)
        {
            this.context = context;
        }
        public void Add(CourseDegreeLevel courseDegreeLevel)
        {
            context.CourseDegreeLevels.Add(courseDegreeLevel);
        }

        public async Task<CourseDegreeLevel> GetCourseDegreeLevel(int id)
        {
            return await context.CourseDegreeLevels
                .SingleOrDefaultAsync(c => c.Id == id); 
        }

        public async Task<QueryResult<CourseDegreeLevel>> GetCourseDegreeLevels(CourseDegreeLevelQuery filter)
        {
            var result = new QueryResult<CourseDegreeLevel>();

            var query = context.CourseDegreeLevels
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(c => c.DegreeLevelName.Contains(filter.Name));
            }

            var columnsMap = new Dictionary<string, Expression<Func<CourseDegreeLevel, object>>>()
            {
                ["Name"] = c => c.DegreeLevelName
            };

            query = query.Applyordering(filter, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(filter);

            result.Items = await query.ToListAsync();

            return result;

        }

        public void Remove(CourseDegreeLevel courseDegreeLevel)
        {
            context.CourseDegreeLevels.Remove(courseDegreeLevel);
        }
    }
}

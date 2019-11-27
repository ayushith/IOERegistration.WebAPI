using IOERegistration.WebAPI.Core.Models;
using IOERegistration.WebAPI.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IOERegistration.WebAPI.UnitTests
{
    [TestFixture]
    public class IQueryableExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Applyordering_IsNullOrWhiteSpace_ReturnsQuery()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
            .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { SortBy = null };

            var columnmaps = new Dictionary<string, Expression<Func<CourseDegreeLevel, object>>>()
            {
                ["Name"] = c => c.DegreeLevelName
            };

            var result = query.Applyordering(filter, columnmaps);

            Assert.That(result.FirstOrDefault().DegreeLevelCode == 'B', Is.True);
        }

        [Test]
        public void Applyordering_ColumnMapDoesNotContainskey_ReturnsQuery()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
        .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { SortBy = "abc" };

            var columnmaps = new Dictionary<string, Expression<Func<CourseDegreeLevel, object>>>()
            {
                ["Name"] = c => c.DegreeLevelName
            };

            var result = query.Applyordering(filter, columnmaps);

            Assert.That(result.FirstOrDefault().DegreeLevelCode == 'B', Is.True);
        }

        [Test]
        public void Applyordering_SortAscendingTrue_ReturnsQueryAsc()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
       .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { SortBy = "Name", IsSortAscending = true };

            var columnmaps = new Dictionary<string, Expression<Func<CourseDegreeLevel, object>>>()
            {
                ["Name"] = c => c.DegreeLevelName
            };

            var result = query.Applyordering(filter, columnmaps);

            Assert.That(result.FirstOrDefault().DegreeLevelName == "Bachelor", Is.True);
        }

        [Test]
        public void Applyordering_SortAscendingFalse_ReturnsQueryDesc()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
       .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { SortBy = "Name", IsSortAscending = false };

            var columnmaps = new Dictionary<string, Expression<Func<CourseDegreeLevel, object>>>()
            {
                ["Name"] = c => c.DegreeLevelName
            };

            var result = query.Applyordering(filter, columnmaps);

            Assert.That(result.FirstOrDefault().DegreeLevelName == "Master", Is.True);
        }

        [Test]
        public void ApplyPaging_PageIsLessThanZero_SetPage()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
            .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { Page = 0 };

            var result = query.ApplyPaging(filter);

            Assert.That(result.Count() == 2);
        }

        [Test]
        public void ApplyPaging_PageSizeIsLessThanZero_SetPage()
        {
            var query = new List<CourseDegreeLevel>()
            {
                new CourseDegreeLevel {  Id = 1 , CreatedBy = "Admin", DegreeLevelCode = 'B', DegreeLevelName = "Bachelor"  },
                new CourseDegreeLevel {  Id = 2 , CreatedBy = "Admin", DegreeLevelCode = 'M', DegreeLevelName = "Master"  }
            }
            .AsQueryable();

            var filter = new CourseDegreeLevelQuery() { PageSize = 0 };

            var result = query.ApplyPaging(filter);

            Assert.That(result.Count() == 2);
        }
    }
}
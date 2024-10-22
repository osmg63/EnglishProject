using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;
using EnglishProject.Service.Concrete;
using System.Diagnostics;

namespace EnglishProject.Core.Repository.Concrete
{
    public class TestRepository : BaseRepository<Test>, ITestRepository
    {
        private readonly WordDbContext _context;

        public TestRepository(WordDbContext wordDbContext) : base(wordDbContext)
        {
            _context = wordDbContext;
        }

        public int KnowTestCount(int UserId)
        {
            var allTest = _context.Tests.ToList();

            var query=from test in _context.Tests
                      where test.UserId == UserId
                      where test.IsCorrect == true
                      select test;
            return query.Count();
        }
      

        public int NotKnowTestCount(int UserId)
        {
            var allTest = _context.Tests.ToList();

            var query = from test in _context.Tests
                        where test.UserId == UserId
                        where test.IsCorrect == false
                        select test;
            return query.Count();
        }
    }
}

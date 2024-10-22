using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data;
using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Concrete
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly WordDbContext _context;
        public UserRepository(WordDbContext wordDbContext) : base(wordDbContext)
        {
            _context = wordDbContext;
        }
    }
}

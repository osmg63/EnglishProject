using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Concrete
{
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        private readonly WordDbContext _context;
        public TransactionRepository(WordDbContext wordDbContext) : base(wordDbContext)
        {
            _context = wordDbContext;
        }
        public void Add(Transaction entity)
        {
            var data = (from transaction in _context.Transactions
                                       where transaction.UserId == entity.UserId && transaction.WordId == entity.WordId
                                       select transaction).FirstOrDefault();

            if (data != null)
            {
           
                data.Know = entity.Know; 
                data.Date = entity.Date; 
            }
            else
            {
                
                _context.Set<Transaction>().Add(entity);
            }

            _context.SaveChanges();
        }

        public List<ForNotTransactionDto> GetWordsNotTransaction(int userId,string wordType)
        {
            var allWords = _context.Words;

            var query = from  transaction in _context.Transactions
                        join word in _context.Words on transaction.WordId equals word.Id
                        where transaction.UserId == userId
                        select word;

            var getWords = allWords
                .Except(query)
                .Where(x => x.WorkType == wordType)
                .OrderBy(x => Guid.NewGuid())
                .Take(20)
                .Select(word => new ForNotTransactionDto
                {
                    Id = word.Id,
                    Terms = word.Terms,
                    Meaning = word.Meaning,
                    Meaning2 = word.Meaning2,
                    Meaning3 = word.Meaning3,
                    WorkType = word.WorkType
                })
                .ToList();
            return getWords;
        }

        public List<KnowsWordDto> GetWordsUserKnows(int userId)
        {

            var query = from transaction in _context.Transactions
                        join word in _context.Words on transaction.WordId equals word.Id
                        where transaction.UserId == userId
                        where transaction.Know == true
                        select new KnowsWordDto
                        {
                            Id = word.Id,
                            Terms = word.Terms,
                            Meaning = word.Meaning,
                            Meaning2 = word.Meaning2,
                            Meaning3 = word.Meaning3,
                            WorkType = word.WorkType
                        };

           

            return query.ToList();
        }
        public int GetWordsUserKnowsCount(int userId)
        {

            var query = from transaction in _context.Transactions
                        join word in _context.Words on transaction.WordId equals word.Id
                        where transaction.UserId == userId
                        where transaction.Know == true
                        select word;

            var getWords = query
                .Count();

            return getWords;
        }
        public List<NotKnowsWordDto> GetWordsUserNotKnows(int userId)
        {
            var allWords = _context.Words;

            var query = from transaction in _context.Transactions
                        join word in _context.Words on transaction.WordId equals word.Id
                        where transaction.UserId == userId
                        where transaction.Know == false
                        select new NotKnowsWordDto
                        {
                            Id = word.Id,
                            Terms = word.Terms,
                            Meaning = word.Meaning,
                            Meaning2 = word.Meaning2,
                            Meaning3 = word.Meaning3,
                            WorkType = word.WorkType
                        };


            var getWords = query
                .ToList();
            return getWords;
        }

    }
}

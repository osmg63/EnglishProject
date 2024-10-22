using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Concrete
{
    public class WordRepsitory : BaseRepository<Word>, IWordRepository
    {
        private readonly WordDbContext _context;
        public WordRepsitory(WordDbContext wordDbContext) : base(wordDbContext)
        {
            _context = wordDbContext;
        }
        public string IncorrectAnswers(string answer) {
           var incorrectAnswers = _context.Words
          .Where(w => w.Meaning != answer)
          .OrderBy(w => Guid.NewGuid()) // Rastgele sıralama
          .Select(w => w.Meaning)
          .FirstOrDefault();
            return incorrectAnswers;
        }

        public TestDto Test()
        {
            var allWords = _context.Words.ToList();

            Random random = new Random();
            var selectedWord = allWords[random.Next(allWords.Count)];

        
          

            var test = new TestDto
            {
                WordId = selectedWord.Id,
                Word = selectedWord.Terms,
                Answer = selectedWord.Meaning,
                WrongWord1 = IncorrectAnswers(selectedWord.Meaning),
                WrongWord2 = IncorrectAnswers(selectedWord.Meaning),
                WrongWord3 = IncorrectAnswers(selectedWord.Meaning),

            };


            return test;

        }

        public Boolean VerifyTest(int wordId,string answer)
        {
            var query =from word in _context.Words
                       where word.Id == wordId
                       where word.Meaning== answer
                       select word;
            if (query.Any())
            {
                return true;
            }
            return false;
        }







    }
}

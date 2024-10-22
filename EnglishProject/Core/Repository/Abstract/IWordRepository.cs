using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Abstract
{
    public interface IWordRepository:IBaseRepository<Word>
    {
        TestDto Test();
        string IncorrectAnswers(string answer);
        Boolean VerifyTest(int wordId, string answer);

    }
}

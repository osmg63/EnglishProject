using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Abstract
{
    public interface ITransactionRepository:IBaseRepository<Transaction>
    {
        List<ForNotTransactionDto> GetWordsNotTransaction(int userId, string wordType);       
        List<NotKnowsWordDto> GetWordsUserNotKnows(int userId);
        List<KnowsWordDto> GetWordsUserKnows(int userId);
        int GetWordsUserKnowsCount(int userId);
        void Add(Transaction entity);


    }

}

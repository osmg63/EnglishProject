using AutoMapper;
using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;

namespace EnglishProject.Service.Concrete
{
    public class TransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        public TransactionService(ITransactionRepository transactionRepository,IMapper mapper)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public void CreateTransaction(CreateTransactionDto transaction)

        {
            transaction.Date= DateTime.Now;
            var data=_mapper.Map<Transaction>(transaction);
            
            _transactionRepository.Add(data);
        }
        public List<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAll();
        }
        public List<ForNotTransactionDto> GetWords(int userId,string wordType)
        {
           return _transactionRepository.GetWordsNotTransaction(userId,wordType);
        }
        public List<KnowsWordDto> GetWordsUserKnows(int userId)
        {
            return _transactionRepository.GetWordsUserKnows(userId);
        }

        public List<NotKnowsWordDto> GetWordsUserNotKnows(int userId)
        {
            return _transactionRepository.GetWordsUserNotKnows(userId);
        }
        public int GetWordsUserNotKnowsCount(int userId)
        {
            return _transactionRepository.GetWordsUserKnowsCount(userId);
        }

    }
}

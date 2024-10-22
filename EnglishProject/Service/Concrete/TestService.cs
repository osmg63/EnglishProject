using AutoMapper;
using EnglishProject.Core.Repository.Abstract;
using EnglishProject.Data.DTOs;
using EnglishProject.Data.Entities;
using System.Security.Cryptography.X509Certificates;

namespace EnglishProject.Service.Concrete
{
    public class TestService
    {
        private readonly IWordRepository _wordRepository;
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;

       

        public TestService(IWordRepository wordRepository, ITestRepository testRepository, IMapper mapper)
        {
            _wordRepository = wordRepository;
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public TestDto Test()
        {
            var data = _wordRepository.Test();
            return data;
        }
        public CreateTestDto AddTest(CreateTestRequestDto test) {



            var isCorrect  = _wordRepository.VerifyTest(test.WordId, test.Answer);
            var data = new Test();
            data.UserId = test.UserId;
            data.WordId= test.WordId;
            data.IsCorrect = isCorrect;
            _testRepository.Add(data);
            var veri = _mapper.Map<CreateTestDto>(data);
            veri.Answer = test.Answer;

            return veri;
        }
        
        public int KnowTestCount(int UserId)
        {
            var data = _testRepository.KnowTestCount(UserId);
            return data;
        }

        public int NotKnowTestCount(int userId)
        {
            var data = _testRepository.NotKnowTestCount(userId);

            return data;
        }
      
    }
}

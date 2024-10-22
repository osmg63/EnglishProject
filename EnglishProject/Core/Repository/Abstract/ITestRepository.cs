using EnglishProject.Data.Entities;

namespace EnglishProject.Core.Repository.Abstract
{
    public interface ITestRepository:IBaseRepository<Test>
    {
        int KnowTestCount(int UserId);
        int NotKnowTestCount(int UserId);
    }
}

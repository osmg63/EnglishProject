using EnglishProject.Data.Entities;

namespace EnglishProject.Data.DTOs
{
    public class CreateTransactionDto
    {
        public Boolean Know { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int WordId { get; set; }
    }
}

namespace EnglishProject.Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Boolean Know { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Word Word { get; set; }
        public int WordId { get; set; }
    }
}

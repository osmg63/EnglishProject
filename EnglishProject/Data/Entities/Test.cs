namespace EnglishProject.Data.Entities
{
    public class Test
    {
        public int Id { get; set; }

        public int WordId { get; set; }
        public int UserId { get; set; }
        public bool IsCorrect { get; set; }
        public virtual User User { get; set; }
        public virtual Word Word { get; set; }


    }
}

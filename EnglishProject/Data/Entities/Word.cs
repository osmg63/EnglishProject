namespace EnglishProject.Data.Entities
{
    public class Word
    {

        public int Id  { get; set; }
        public string Terms { get; set; }
        public string Meaning { get; set; }
        public string Meaning2 { get; set; }
        public string Meaning3 { get; set; }
        public string WorkType { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}

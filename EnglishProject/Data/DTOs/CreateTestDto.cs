namespace EnglishProject.Data.DTOs
{
    public class CreateTestDto
    {
        public int WordId { get; set; }
        public int UserId { get; set; }
        public bool IsCorrect { get; set; }
        public string Answer { get; set; }


    }
}

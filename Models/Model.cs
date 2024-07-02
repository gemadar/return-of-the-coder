namespace return_of_the_coder.Models
{
    public class Model
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class YearModel
    {
        public int Year { get; set; }
    }

    public class PersonModel
    {
        public int AgeOfDeath1 { get; set; }

        public int YearOfDeath1 { get; set; }

        public int AgeOfDeath2 { get; set; }

        public int YearOfDeath2 { get; set; }
    }
}

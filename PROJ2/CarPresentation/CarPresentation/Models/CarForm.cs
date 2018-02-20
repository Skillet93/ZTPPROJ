namespace CarPresentation.Models
{
    public class CarForm
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string FullName {
            get { return Brand + " " + Model; }
        }
        public int MaxSpeed { get; set; }
        public int Seats { get; set; }
        public string DescriptionLang { get; set; }
        public string Description { get; set; }
    }
}
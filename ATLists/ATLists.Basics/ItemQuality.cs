namespace ATLists.Basics
{
    public class ItemQuality
    {
        public double Percentage
        {
            get;
            set;
        }
        public int NumberOfStars
        {
            get;
            set;
        }
        public double Stars
        {
            get
            {
                return Percentage / NumberOfStars;
            }
            set
            {
                Percentage = (value / NumberOfStars) * 100;
            }
        }
    }
}

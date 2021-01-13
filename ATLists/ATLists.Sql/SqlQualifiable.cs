using SQLite;

namespace ATLists.SQL
{
    public class SqlQualifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


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
    }
}

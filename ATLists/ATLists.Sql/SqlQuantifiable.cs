using SQLite;

namespace ATLists.SQL
{
    public class SqlQuantifiable
    {
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get;
            set;
        }
        public int ImplementorId { get; set; }



        public double Ammount
        {
            get;
            set;
        }
        public string AmmountSuffix
        {
            get;
            set;
        }
        public string AmmountShortSuffix
        {
            get;
            set;
        }

        public int ABTreshold
        {
            get;
            set;
        }
        public string Separator
        {
            get;
            set;
        }
        public string ShortSeparator
        {
            get;
            set;
        }
        public string AmmountSuffix2
        {
            get;
            set;
        }
        public string AmmountShortSuffix2
        {
            get;
            set;
        }

        public bool ShowOne
        {
            get;
            set;
        }
        public bool ShowZero
        {
            get;
            set;
        }

        public double WarningAmmount
        {
            get;
            set;
        }
        public double CriticalAmmount
        {
            get;
            set;
        }
    }
}

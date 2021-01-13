using SQLite;

namespace ATLists.SQL
{
    public class SqlColorable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int ForeColor { get; set; }
        public int BackColor { get; set; }

        public string ForeColorsJson { get; set; }
        public string BackColorsJson { get; set; }
    }
}

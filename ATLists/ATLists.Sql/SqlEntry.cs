using SQLite;

namespace ATLists.SQL
{
    public class SqlEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string EntryType { get; set; }


        public int SqlColorable { get; set; }
        public int SqlIconable { get; set; }
        public int SqlMultyText { get; set; }
        public int SqlQualifiable { get; set; }
        public int SqlQuantifiable { get; set; }
        public int SqlSingleText { get; set; }
    }
}

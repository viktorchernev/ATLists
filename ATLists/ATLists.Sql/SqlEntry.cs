using SQLite;

namespace ATLists.SQL
{
    public class SqlEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public int EntryType { get; set; }


        public byte SqlColorable { get; set; }
        public byte SqlIconable { get; set; }
        public byte SqlMultyText { get; set; }
        public byte SqlQualifiable { get; set; }
        public byte SqlQuantifiable { get; set; }
        public byte SqlSingleText { get; set; }
    }
}

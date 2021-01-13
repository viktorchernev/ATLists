using SQLite;

namespace ATLists.SQL
{
    public class SqlCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string CategoryType { get; set; }


        public int SqlEntryStorage { get; set; }
        public int SqlColorable { get; set; }
        public int SqlIconable { get; set; }
        public int SqlSingleText { get; set; }
    }
}

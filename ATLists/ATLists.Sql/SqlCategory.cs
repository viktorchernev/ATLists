using SQLite;

namespace ATLists.SQL
{
    public class SqlCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string CategoryType { get; set; }


        public byte SqlEntryStorage { get; set; }
        public byte SqlColorable { get; set; }
        public byte SqlIconable { get; set; }
        public byte SqlSingleText { get; set; }
    }
}

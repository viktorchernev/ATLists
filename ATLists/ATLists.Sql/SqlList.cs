using SQLite;

namespace ATLists.SQL
{
    public class SqlList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public int ListType { get; set; }


        public byte SqlCategoryStorage { get; set; }
        public byte SqlColorable { get; set; }
        public byte SqlIconable { get; set; }
        public byte SqlSingleText { get; set; }
    }
}

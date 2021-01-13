using SQLite;

namespace ATLists.SQL
{
    public class SqlList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string ListType { get; set; }


        public int SqlColorable { get; set; }
        public int SqlIconable { get; set; }
        public int SqlSingleText { get; set; }
    }
}

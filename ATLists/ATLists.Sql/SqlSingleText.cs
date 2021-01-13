using SQLite;

namespace ATLists.SQL
{
    public class SqlSingleText
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string Text { get; set; }
    }
}

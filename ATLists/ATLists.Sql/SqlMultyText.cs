using SQLite;

namespace ATLists.SQL
{
    public class SqlMultyText
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public string TextsJson { get; set; }
    }
}

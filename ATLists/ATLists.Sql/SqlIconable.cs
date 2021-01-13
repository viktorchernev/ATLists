using SQLite;

namespace ATLists.SQL
{
    public class SqlIconable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }



        public string ImageSource { get; set; }
    }
}

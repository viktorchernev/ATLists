using SQLite;

namespace ATLists.SQL
{
    public class SqlEntryStorage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public int[] Entries { get; set; }
    }
}

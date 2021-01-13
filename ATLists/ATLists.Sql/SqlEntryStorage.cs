using SQLite;

namespace ATLists.SQL
{
    public class SqlEntryStorage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public int CategoryId { get; set; }
        public int EntryId { get; set; }
    }
}

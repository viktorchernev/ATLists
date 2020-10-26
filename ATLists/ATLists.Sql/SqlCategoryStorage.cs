using SQLite;

namespace ATLists.SQL
{
    public class SqlCategoryStorage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public byte[] Categories { get; set; }
    }
}

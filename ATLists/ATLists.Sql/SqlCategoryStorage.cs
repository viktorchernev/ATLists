using SQLite;

namespace ATLists.SQL
{
    public class SqlCategoryStorage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }


        public int ListId { get; set; }
        public int CategoryId { get; set; }
    }
}

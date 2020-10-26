using ATLists.SQL;

namespace ATLists
{
    public class CategoryBase
    {
        public virtual CategoryType CategoryType { get; }

        public SqlCategory SqlItem;
    }
}

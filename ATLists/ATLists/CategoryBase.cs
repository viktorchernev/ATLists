using ATLists.SQL;

namespace ATLists
{
    public class CategoryBase
    {
        public virtual string CategoryType { get; }

        public SqlCategory SqlItem;
    }
}

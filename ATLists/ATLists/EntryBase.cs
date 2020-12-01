using ATLists.SQL;

namespace ATLists
{
    public class EntryBase
    {
        public virtual string EntryType { get; }

        public SqlEntry SqlItem;
    }
}

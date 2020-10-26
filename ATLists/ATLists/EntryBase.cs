using ATLists.SQL;

namespace ATLists
{
    public class EntryBase
    {
        public virtual EntryType EntryType { get; }

        public SqlEntry SqlItem;
    }
}

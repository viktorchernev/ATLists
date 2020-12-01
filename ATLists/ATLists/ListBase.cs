using ATLists.SQL;

namespace ATLists
{
    public class ListBase
    {
        public virtual string ListType { get; }

        public SqlList SqlItem;
        //public IViewItem viewItem;
    }
}
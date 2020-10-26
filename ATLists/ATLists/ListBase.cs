using ATLists.SQL;

namespace ATLists
{
    public class ListBase
    {
        public virtual ListType ListType { get; }

        public SqlList SqlItem;
        //public IViewItem viewItem;
    }
}
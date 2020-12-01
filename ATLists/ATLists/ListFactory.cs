using ATLists.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATLists
{
    public static class ListFactory
    {
        public static ListBase GetList(SqlList sqll)
        {
            return new ListBasic(sqll);
        }
        public static ListBasic GetListBasic(SqlList sqll)
        {
            return new ListBasic(sqll);
        }
    }
}
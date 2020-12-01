using ATLists.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATLists
{
    public static class EntryFactory
    {
        static Dictionary<string, Func<SqlEntry, EntryBase>> REGISTER;


        static EntryFactory()
        {
            REGISTER = new Dictionary<string, Func<SqlEntry, EntryBase>>();
            REGISTER.Add("Basic", GetEntryBasic);
        }


        public static EntryBase GetEntry(SqlEntry sqle)
        {
            foreach(KeyValuePair<string, Func<SqlEntry, EntryBase>> kvp in REGISTER)
            {
                if (kvp.Key == sqle.EntryType)
                {
                    return kvp.Value(sqle);
                }
            }

            return null;
        }


        public static EntryBasic GetEntryBasic(SqlEntry sqle)
        {
            return new EntryBasic(sqle);
        }
    }
}

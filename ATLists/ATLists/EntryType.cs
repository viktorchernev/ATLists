using System;

namespace ATLists
{
    [Flags]
    public enum EntryType
    {
        Basic = 0,
        Qualifiable = 1,
        Quantifiable = 2,
        Multitext = 4,
    }
}

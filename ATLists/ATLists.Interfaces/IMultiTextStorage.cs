using ATLists.SQL;
using System.Collections.Generic;

namespace ATLists.Interfaces
{
    public interface IMultiTextStorage
    {
        //SQLObject
        SqlMultyText SqlMultyTextObject { get; }


        //Data Storage
        Dictionary<string, string> Texts { get; }


        //Data Setters
        void AddText(string key, string text);
        void RemoveText(string key);

        //Compound Getters
    }
}

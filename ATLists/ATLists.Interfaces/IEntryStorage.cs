using System;
using System.Collections.Generic;
using ATLists;
using ATLists.SQL;


namespace ATLists.Interfaces
{
    public interface IEntryStorage
    {
        //Data Storage
        List<EntryBase> Entries { get; }


        //Data Setters
        void AddEntry(EntryBase entry);
        void RemoveEntry(EntryBase entry);


        //Compound Getters
        EntryBase GetEntry(SqlEntry sqle);
    }
}

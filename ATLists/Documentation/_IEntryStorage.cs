/* IEntryStorage
 * "IEntryStorage" is an interface for storing entries. */



/// IMPLEMENTATION:
//IEntryStorage
public SqlEntryStorage SqlEntryStorageObject
{
    get;
    private set;
}
public List<EntryBase> Entries
{
    get;
    private set;
}
public void AddEntry(EntryBase entry)
{
    Entries.Add(entry);

    //save to DataBase
    List<byte> ids = new List<byte>();
    foreach (EntryBase e in Entries) ids.Add((byte)e.SqlItem.Id);
    SqlEntryStorageObject.Entries = ids.ToArray();
    Procedures.Update(SqlEntryStorageObject);
}
public void RemoveEntry(EntryBase entry)
{
    Entries.Remove(entry);

    //save to DataBase
    List<byte> ids = new List<byte>();
    foreach (EntryBase e in Entries) ids.Add((byte)e.SqlItem.Id);
    SqlEntryStorageObject.Entries = ids.ToArray();
    Procedures.Update(SqlEntryStorageObject);
}
public EntryBase GetEntry(SqlEntry sqle)
{
    EntryBase entry = null;
    entry = EntryFactory.GetEntry(sqle);
    return entry;
}


/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlEntryStorage es = Procedures.EntryStorages[SQLOBJECT.SqlEntryStorage];

    //IEntryStorage
    SqlEntryStorageObject = es;
    Entries = new List<EntryBase>();
    foreach (byte b in es.Entries)
    {
        SqlEntry sqle = Procedures.Entries[b];
        EntryBase entry = GetEntry(sqle);
        Entries.Add(entry);
    }
}
public CTOR()
{
    //ISingleTextStorage - Data
    Text = text;
    //ISingleTextStorage - SQL
    SqlSingleTextObject = new SqlSingleText() { Text = text };
    Procedures.Insert(SqlEntryStorageObject);

    SQLOBJECT.SqlEntryStorage = (byte)SqlEntryStorageObject.Id;
}
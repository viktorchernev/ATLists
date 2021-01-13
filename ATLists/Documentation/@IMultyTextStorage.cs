/* IMultyTextStorage
 * "IMultyTextStorage" is an interface for storing multiple texts. */

//USINGS:
using ATLists;
using ATLists.Interfaces;
using ATLists.SQL;
using Newtonsoft.Json;



/// IMPLEMENTATION:
//IMultyTextStorage
public SqlMultyText SqlMultyTextObject
{
    get;
    private set;
}
public Dictionary<string, string> Texts
{
    get;
    private set;
}
public void AddText(string key, string text)
{
    if (Texts.ContainsKey(key))
    {
        Texts[key] = text;
    }
    else
    {
        Texts.Add(key, text);
    }

    //Save to DB
    SqlMultyTextObject.TextsJson = JsonConvert.SerializeObject(Texts);
    Procedures.Update(SqlMultyTextObject);
}
public void RemoveText(string key)
{
    if (Texts.ContainsKey(key))
    {
        Texts.Remove(key);

        //Save to DB
        SqlMultyTextObject.TextsJson = JsonConvert.SerializeObject(Texts);
        Procedures.Update(SqlMultyTextObject);
    }
}



/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlMultyText mt = Procedures.MultyTexts[SQLOBJECT.SqlMultyText];

    //IMultiTextStorage
    SqlMultyTextObject = mt;
    Texts = new Dictionary<string, string>();
    Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(mt.TextsJson);
}
public CTOR()
{
    //IMultyTextStorage - Data
    Texts = new Dictionary<string, string>();
    //IMultyTextStorage - SQL
    SqlMultyTextObject = new SqlMultyText();
    SqlMultyTextObject.TextsJson = "";
    Procedures.Insert(SqlMultyTextObject);


    SQLOBJECT.SqlMultyTextStorage = SqlMultyTextObject.Id;
}
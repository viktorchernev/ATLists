/* ISingleTextStorage 
 * "ISingleTextStorage" is an interface for storing a single string. */



/// IMPLEMENTATION:
//ISingleTextStorage
public SqlSingleText SqlSingleTextObject
{
    get;
    private set;
}
public string Text
{
    get;
    private set;
}
public void SetText(string text)
{
    Text = text;

    //save to DataBase
    SqlSingleTextObject.Text = Text;
    Procedures.Update(SqlSingleTextObject);
}



/// CTOR:
public CTOR(int sqlObjectId)
{
    SqlSingleText st = Procedures.SingleTexts[sqlObjectId];

    //SqlSingleText
    SqlSingleTextObject = st;
    Text = st.Text;
}
public CTOR(SQLOBJECT)
{
    //SqlSingleText
    SqlSingleTextObject = SQLOBJECT;
    Text = st.Text;
}
public CTOR(string text)
{
    //ISingleTextStorage - Data
    Text = text;
    //ISingleTextStorage - SQL
    SqlSingleTextObject = new SqlSingleText() { Text = text };
    Procedures.Insert(SqlSingleTextObject);

    SQLOBJECT.SqlSingleText = (byte)SqlSingleTextObject.Id;
}
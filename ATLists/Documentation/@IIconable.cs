/* IIconable
 * "IIconable" is an interface for having an icon. */



/// IMPLEMENTATION:
//IIconable
public SqlIconable SqlIconableObject
{
    get;
    private set;
}
public string ImageSource
{
    get;
    private set;
}
public void SetImage(string source)
{
    ImageSource = source;

    //save to DataBase
    SqlIconableObject.ImageSource = source;
    Procedures.Update(SqlIconableObject);
}



/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlIconable i = Procedures.Iconables[SQLOBJECT.SqlIconable];

    //IIconable
    SqlIconableObject = i;
    ImageSource = i.ImageSource;
}
public CTOR(string iconName = null)
{
    //IIconable - Data
    ImageSource = iconName;
    //IIconable - SQL
    SqlIconableObject = new SqlIconable();
    SqlIconableObject.ImageSource = iconName;
    Procedures.Insert(SqlIconableObject);

    SQLOBJECT.SqlIconable = SqlIconableObject.Id;
}
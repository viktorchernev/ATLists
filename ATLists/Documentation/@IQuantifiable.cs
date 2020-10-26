/* IQuantifiable
 * "IQuantifiable" is an interface for storing an object quantity. */



/// IMPLEMENTATION:
//IQuantifiable
public SqlQuantifiable SqlQuantifiableObject
{
    get;
    private set;
}
public ItemQuantity Quantity
{
    get;
    set;
}
public string AmmountText
{
    get
    {
        string s;
        if (Quantity.ABTreshold > -1)
        {
            double a = (int)Math.Floor(((double)Quantity.Ammount) / Quantity.ABTreshold);
            double b = Quantity.Ammount % Quantity.ABTreshold;
            s = a.ToString();

            if (!string.IsNullOrEmpty(Quantity.AmmountSuffix) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountSuffix))
            {
                s += Quantity.AmmountSuffix;
            }

            s += Quantity.Separator;
            s += b.ToString();

            if (!string.IsNullOrEmpty(Quantity.AmmountSuffix2) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountSuffix2))
            {
                s += Quantity.AmmountSuffix2;
            }
        }
        else
        {
            s = Quantity.Ammount.ToString();
            if (!string.IsNullOrEmpty(Quantity.AmmountShortSuffix) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountShortSuffix))
            {
                s += Quantity.AmmountShortSuffix;
            }
        }
        return s;
    }
}
public string AmmountShortText
{
    get
    {
        string s;
        if (Quantity.ABTreshold > -1)
        {
            double a = (int)Math.Floor(((double)Quantity.Ammount) / Quantity.ABTreshold);
            double b = Quantity.Ammount % Quantity.ABTreshold;
            s = a.ToString();

            if (!string.IsNullOrEmpty(Quantity.AmmountShortSuffix) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountShortSuffix))
            {
                s += Quantity.AmmountShortSuffix;
            }

            s += Quantity.ShortSeparator;
            s += b.ToString();

            if (!string.IsNullOrEmpty(Quantity.AmmountShortSuffix2) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountShortSuffix2))
            {
                s += Quantity.AmmountShortSuffix2;
            }
        }
        else
        {
            s = Quantity.Ammount.ToString();
            if (!string.IsNullOrEmpty(Quantity.AmmountShortSuffix) &&
        !string.IsNullOrWhiteSpace(Quantity.AmmountShortSuffix))
            {
                s += Quantity.AmmountShortSuffix;
            }
        }
        return s;
    }
}
public void SetAmmount(double ammount)
{
    Quantity.Ammount = ammount;

    //save to DataBase
    SqlQuantifiableObject.Ammount = ammount;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetAmmountSuffix(string suffix)
{
    Quantity.AmmountSuffix = suffix;

    //save to DataBase
    SqlQuantifiableObject.AmmountSuffix = suffix;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetAmmountShortSuffix(string suffix)
{
    Quantity.AmmountShortSuffix = suffix;

    //save to DataBase
    SqlQuantifiableObject.AmmountShortSuffix = suffix;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetABTreshold(int treshold)
{
    Quantity.ABTreshold = treshold;

    //save to DataBase
    SqlQuantifiableObject.ABTreshold = treshold;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetSeparator(string separator)
{
    Quantity.Separator = separator;

    //save to DataBase
    SqlQuantifiableObject.Separator = separator;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetShortSeparator(string separator)
{
    Quantity.ShortSeparator = separator;

    //save to DataBase
    SqlQuantifiableObject.ShortSeparator = separator;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetAmmountShortSuffix2(string suffix)
{
    Quantity.AmmountShortSuffix2 = suffix;

    //save to DataBase
    SqlQuantifiableObject.AmmountShortSuffix2 = suffix;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetAmmountSuffix2(string suffix)
{
    Quantity.AmmountSuffix2 = suffix;

    //save to DataBase
    SqlQuantifiableObject.AmmountSuffix2 = suffix;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetCriticalAmmount(double criticalAmmount)
{
    Quantity.CriticalAmmount = criticalAmmount;

    //save to DataBase
    SqlQuantifiableObject.CriticalAmmount = criticalAmmount;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetWarningAmmount(double warningAmmount)
{
    Quantity.WarningAmmount = warningAmmount;

    //save to DataBase
    SqlQuantifiableObject.WarningAmmount = warningAmmount;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetShowOne(bool showone)
{
    Quantity.ShowOne = showone;

    //save to DataBase
    SqlQuantifiableObject.ShowOne = showone;
    Procedures.Update(SqlQuantifiableObject);
}
public void SetShowZero(bool showzero)
{
    Quantity.ShowZero = showzero;

    //save to DataBase
    SqlQuantifiableObject.ShowZero = showzero;
    Procedures.Update(SqlQuantifiableObject);
}


/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlQuantifiable q = Procedures.Quantifiables[e.SqlQuantifiable];

    //IQuantifiable
    SqlQuantifiableObject = q;
    Quantity = new ItemQuantity();
    Quantity.Ammount = q.Ammount;
    Quantity.AmmountSuffix = q.AmmountSuffix;
    Quantity.AmmountSuffix2 = q.AmmountSuffix;
    Quantity.AmmountShortSuffix = q.AmmountShortSuffix;
    Quantity.AmmountShortSuffix2 = q.AmmountShortSuffix2;
    Quantity.ABTreshold = q.ABTreshold;
    Quantity.ShowOne = q.ShowOne;
    Quantity.ShowZero = q.ShowZero;
    Quantity.WarningAmmount = q.WarningAmmount;
    Quantity.CriticalAmmount = q.CriticalAmmount;
}
public CTOR(
    double ammount, string suffix = null, string shortSuffix = null,
    bool showOne = true, bool showZero = true,
    int warningAmmount = -1, int criticalAmmount = -1)
{
    //IQuantifiable - Data
    Quantity = new ItemQuantity()
    {
        Ammount = ammount,
        AmmountSuffix = suffix,
        AmmountShortSuffix = shortSuffix,

        ABTreshold = -1,
        AmmountSuffix2 = null,
        AmmountShortSuffix2 = null,

        ShowOne = showOne,
        ShowZero = showZero,

        WarningAmmount = warningAmmount,
        CriticalAmmount = criticalAmmount
    };
    //IQuantifiable - SQL
    SqlQuantifiableObject = new SqlQuantifiable()
    {
        Ammount = ammount,
        AmmountSuffix = suffix,
        AmmountShortSuffix = shortSuffix,

        ABTreshold = -1,
        AmmountSuffix2 = null,
        AmmountShortSuffix2 = null,

        ShowOne = showOne,
        ShowZero = showZero,

        WarningAmmount = warningAmmount,
        CriticalAmmount = criticalAmmount
    };
    Procedures.Insert(SqlQuantifiableObject);

    SQLOBJECT.SqlQuantifiable = (byte)SqlQuantifiableObject.Id;
}
public CTOR(
    double ammount, int treshold,
    string suffix = null, string shortSuffix = null,
    string suffix2 = null, string shortSuffix2 = null,
    bool showOne = true, bool showZero = true,
    int warningAmmount = -1, int criticalAmmount = -1)
{
    //IQuantifiable - Data
    Quantity = new ItemQuantity()
    {
        Ammount = ammount,
        AmmountSuffix = suffix,
        AmmountShortSuffix = shortSuffix,

        ABTreshold = treshold,
        AmmountSuffix2 = suffix2,
        AmmountShortSuffix2 = shortSuffix2,

        ShowOne = showOne,
        ShowZero = showZero,

        WarningAmmount = warningAmmount,
        CriticalAmmount = criticalAmmount
    };
    //IQuantifiable - SQL
    SqlQuantifiableObject = new SqlQuantifiable()
    {
        Ammount = ammount,
        AmmountSuffix = suffix,
        AmmountShortSuffix = shortSuffix,

        ABTreshold = treshold,
        AmmountSuffix2 = suffix2,
        AmmountShortSuffix2 = shortSuffix2,

        ShowOne = showOne,
        ShowZero = showZero,

        WarningAmmount = warningAmmount,
        CriticalAmmount = criticalAmmount
    };
    Procedures.Insert(SqlQuantifiableObject);

    SQLOBJECT.SqlQuantifiable = (byte)SqlQuantifiableObject.Id;
}
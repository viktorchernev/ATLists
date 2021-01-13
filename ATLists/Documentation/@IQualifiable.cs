/* IQualifiable
 * "IQualifiable" is an interface for storing an object quality state. */



/// IMPLEMENTATION:
//IQualifiable
public SqlQualifiable SqlQualifiableObject
{
    get;
    private set;
}
public ItemQuality Quality
{
    get;
    private set;
}
public void SetNumberOfStars(int numOfStars)
{
    Quality.NumberOfStars = numOfStars;

    //save to DataBase
    SqlQualifiableObject.NumberOfStars = numOfStars;
    Procedures.Update(SqlQualifiableObject);
}
public void SetPercentage(double percentage)
{
    Quality.Percentage = percentage;

    //save to DataBase
    SqlQualifiableObject.Percentage = percentage;
    Procedures.Update(SqlQualifiableObject);
}
public void SetStarts(double stars)
{
    Quality.Stars = stars;

    //save to DataBase
    SqlQualifiableObject.Percentage = Quality.Percentage;
    Procedures.Update(SqlQualifiableObject);
}



/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlQualifiable q = Procedures.Qualifiables[SQLOBJECT.SqlQualifiable];

    //IQualifiable
    SqlQualifiableObject = q;
    Quality = new ItemQuality();
    Quality.Percentage = q.Percentage;
    Quality.NumberOfStars = q.NumberOfStars;
}
public CTOR(double quality = 100, int numberOfStars = 5)
{
    //IQualifiable - Data
    Quality = new ItemQuality()
    {
        Percentage = quality,
        NumberOfStars = numberOfStars
    };
    //IQualifiable - SQL
    SqlQualifiableObject = new SqlQualifiable()
    {
        Percentage = quality,
        NumberOfStars = numberOfStars
    };
    Procedures.Insert(SqlQualifiableObject);

    SQLOBJECT.SqlQualifiable = SqlQualifiableObject.Id;
}
/* ICategoryStorage
 * "ICategoryStorage" is an interface for storing categories. */



/// IMPLEMENTATION:
//ICategoryStorage
public SqlCategoryStorage SqlCategoryStorageObject
{
    get;
    private set;
}
public List<CategoryBase> Categories
{
    get;
    private set;
}
public void AddCategory(CategoryBase category)
{
    Categories.Add(category);

    //save to DataBase
    List<int> ids = new List<int>();
    foreach (CategoryBase c in Categories) ids.Add(c.SqlItem.Id);
    SqlCategoryStorageObject.Categories = ids.ToArray();
    Procedures.Update(SqlCategoryStorageObject);
}
public void RemoveCategory(CategoryBase category)
{
    Categories.Remove(category);

    //save to DataBase
    List<int> ids = new List<int>();
    foreach (CategoryBase c in Categories) ids.Add(c.SqlItem.Id);
    SqlCategoryStorageObject.Categories = ids.ToArray();
    Procedures.Update(SqlCategoryStorageObject);
}
public CategoryBase GetCategory(SqlCategory sqlc)
{
    CategoryBase cat = null;
    cat = CategoryFactory.GetCategory(sqlc);
    return cat;
}



/// CTOR:
public CTOR(SQLOBJECT)
{
    SqlCategoryStorage cs = Procedures.CategoryStorages[SQLOBJECT.SqlCategoryStorage];

    //ICategryStorage
    SqlCategoryStorageObject = cs;
    Categories = new List<CategoryBase>();
    foreach (int b in cs.Categories)
    {
        SqlCategory sqlc = Procedures.Categories[b];
        CategoryBase cat = GetCategory(sqlc);
        Categories.Add(cat);
    }
}
public CTOR()
{
    //ICategoryStorage - Data
    Categories = new List<CategoryBase>();
    //ICategoryStorage - SQL
    SqlCategoryStorageObject = new SqlCategoryStorage();
    Procedures.Insert(SqlCategoryStorageObject);

    SQLOBJECT.SqlCategoryStorage = SqlCategoryStorageObject.Id;
}
using ATLists.Interfaces;
using ATLists.SQL;
using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Drawing;

namespace ATLists
{
    public class ListBasic : ListBase, ISingleTextStorage, IIconable, ICategoryStorage //IColorable
    {
        public override ListType ListType
        {
            get
            {
                return ListType.Basic;
            }
        }



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

            //update View
        }



        //IColorable
        //public SqlColorable SqlColorableObject
        //{
        //    get;
        //    private set;
        //}
        //public Color ForeColor
        //{
        //    get;
        //    private set;
        //}
        //public Color BackColor
        //{
        //    get;
        //    private set;
        //}
        //public Dictionary<string, Color> ForeColors
        //{
        //    get;
        //    private set;
        //}
        //public Dictionary<string, Color> BackColors
        //{
        //    get;
        //    private set;
        //}
        //public void SetForeColor(Color color)
        //{
        //    ForeColor = color;

        //    //Save to DB
        //    SqlColorableObject.ForeColor = color.ToArgb();
        //    Procedures.Update(SqlColorableObject);

        //    //update View
        //}
        //public void SetBackColor(Color color)
        //{
        //    BackColor = color;

        //    //Save to DB
        //    SqlColorableObject.BackColor = color.ToArgb();
        //    Procedures.Update(SqlColorableObject);

        //    //update View
        //}
        //public void SetColorTheme(string key)
        //{
        //    ForeColor = ForeColors[key];
        //    BackColor = ForeColors[key];

        //    //Save to DB
        //    SqlColorableObject.ForeColor = ForeColor.ToArgb();
        //    SqlColorableObject.BackColor = BackColor.ToArgb();
        //    Procedures.Update(SqlColorableObject);

        //    //update View
        //}
        //public void AddForeColor(string key, Color color)
        //{
        //    ForeColors.Add(key, color);

        //    //Save to DB
        //    SqlColorableObject.ForeColorsJson = JsonConvert.SerializeObject(ForeColors);
        //    Procedures.Update(SqlColorableObject);
        //}
        //public void AddBackColor(string key, Color color)
        //{
        //    BackColors.Add(key, color);

        //    //Save to DB
        //    SqlColorableObject.BackColorsJson = JsonConvert.SerializeObject(BackColors);
        //    Procedures.Update(SqlColorableObject);
        //}
        //public void RemoveForeColor(string key)
        //{
        //    ForeColors.Remove(key);

        //    //Save to DB
        //    SqlColorableObject.ForeColorsJson = JsonConvert.SerializeObject(ForeColors);
        //    Procedures.Update(SqlColorableObject);
        //}
        //public void RemoveBackColor(string key)
        //{
        //    BackColors.Remove(key);

        //    //Save to DB
        //    SqlColorableObject.BackColorsJson = JsonConvert.SerializeObject(BackColors);
        //    Procedures.Update(SqlColorableObject);
        //}



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

            //update View
        }



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
            List<byte> ids = new List<byte>();
            foreach (CategoryBase c in Categories) ids.Add((byte)c.SqlItem.Id);
            SqlCategoryStorageObject.Categories = ids.ToArray();
            Procedures.Update(SqlCategoryStorageObject);

            //update View
        }
        public void RemoveCategory(CategoryBase category)
        {
            Categories.Remove(category);

            //save to DataBase
            List<byte> ids = new List<byte>();
            foreach (CategoryBase c in Categories) ids.Add((byte)c.SqlItem.Id);
            SqlCategoryStorageObject.Categories = ids.ToArray();
            Procedures.Update(SqlCategoryStorageObject);

            //update View
        }



        //Ctor
        public ListBasic(string text, string iconName = null)
        {
            //ISingleTextStorage - Data
            Text = text;
            //ISingleTextStorage - SQL
            SqlSingleTextObject = new SqlSingleText() { Text = text };
            Procedures.Insert(SqlSingleTextObject);


            //IColorable - Data
            //ForeColors = new Dictionary<string, Color>();
            //BackColors = new Dictionary<string, Color>();
            //ForeColor = viewItem.ForeColor;
            //BackColor = viewItem.BackColor;
            ////IColorable - SQL
            //SqlColorableObject = new SqlColorable();
            //SqlColorableObject.ForeColor = ForeColor.ToArgb();
            //SqlColorableObject.BackColor = BackColor.ToArgb();
            //SqlColorableObject.ForeColorsJson = "";
            //SqlColorableObject.BackColorsJson = "";
            //Procedures.Insert(SqlColorableObject);

            //IIconable
            ImageSource = iconName;
            SqlIconableObject = new SqlIconable();
            SqlIconableObject.ImageSource = iconName;
            Procedures.Insert(SqlIconableObject);

            //ICategoryStorage
            Categories = new List<CategoryBase>();
            SqlCategoryStorageObject = new SqlCategoryStorage();
            Procedures.Insert(SqlCategoryStorageObject);

            //Set SQL
            SqlItem = new SqlList();
            SqlItem.SqlSingleText = (byte)SqlSingleTextObject.Id;
            //SqlItem.SqlColorable = (byte)SqlColorableObject.Id;
            SqlItem.SqlIconable = (byte)SqlIconableObject.Id;
            SqlItem.SqlCategoryStorage = (byte)SqlCategoryStorageObject.Id;
            SqlItem.ListType = (int)ListType;
            Procedures.Insert(SqlItem);
        }
        public ListBasic(SqlList list)
        {
            SqlSingleText st = Procedures.SingleTexts[list.SqlSingleText];
            //SqlColorable c = Procedures.Colorables[list.SqlColorable];
            SqlIconable i = Procedures.Iconables[list.SqlIconable];
            SqlCategoryStorage cs = Procedures.CategoryStorages[list.SqlCategoryStorage];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

            //IColorable
            //SqlColorableObject = c;
            //ForeColor = Color.FromArgb(c.ForeColor);
            //BackColor = Color.FromArgb(c.BackColor);
            //ForeColors = JsonConvert.DeserializeObject<Dictionary<string, Color>>(c.ForeColorsJson);
            //BackColors = JsonConvert.DeserializeObject<Dictionary<string, Color>>(c.BackColorsJson);

            //IIconed
            SqlIconableObject = i;
            ImageSource = i.ImageSource;

            //ICategryStorage
            SqlCategoryStorageObject = cs;
            Categories = new List<CategoryBase>();
            foreach (byte b in cs.Categories)
            {
                SqlCategory sqlc = Procedures.Categories[b];
                CategoryBase cat = GetCategory(sqlc);
                Categories.Add(cat);
            }
        }
        CategoryBase GetCategory(SqlCategory sqlc)
        {
            CategoryBase cat = null;
            cat = new CategoryBasic(sqlc);
            return cat;
        }
    }
}

using ATLists.Interfaces;
using ATLists.SQL;
using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Drawing;

namespace ATLists
{
    public class ListBasic : ListBase, ISingleTextStorage, IIconable, ICategoryStorage //IColorable
    {
        public override string ListType
        {
            get
            {
                return "Basic";
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
        public CategoryBase GetCategory(SqlCategory sqlc)
        {
            CategoryBase cat = null;
            cat = CategoryFactory.GetCategory(sqlc);
            return cat;
        }



        //Ctor
        public ListBasic(string text, string iconName = null)
        {
            //ISingleTextStorage - Data
            Text = text;
            //ISingleTextStorage - SQL
            SqlSingleTextObject = new SqlSingleText() { Text = text };
            Procedures.Insert(SqlSingleTextObject);

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
            SqlItem.SqlIconable = (byte)SqlIconableObject.Id;
            SqlItem.SqlCategoryStorage = (byte)SqlCategoryStorageObject.Id;
            SqlItem.ListType = ListType;
            Procedures.Insert(SqlItem);
        }
        public ListBasic(SqlList list)
        {
            SqlItem = list;
            SqlSingleText st = Procedures.SingleTexts[list.SqlSingleText];
            SqlIconable i = Procedures.Iconables[list.SqlIconable];
            SqlCategoryStorage cs = Procedures.CategoryStorages[list.SqlCategoryStorage];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

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
    }
}

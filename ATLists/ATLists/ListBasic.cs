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
        public List<CategoryBase> Categories
        {
            get;
            private set;
        }
        public void AddCategory(CategoryBase category)
        {
            Categories.Add(category);

            //save to DataBase
            SqlCategoryStorage scs = new SqlCategoryStorage()
            {
                ListId = SqlItem.Id,
                CategoryId = category.SqlItem.Id
            };
            Procedures.Insert(scs);
        }
        public void RemoveCategory(CategoryBase category)
        {
            Categories.Remove(category);

            //remove from DataBase
            //Procedures.RemoveCategory(category.SqlItem.Id);
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

            //Set SQL
            SqlItem = new SqlList();
            SqlItem.SqlSingleText = SqlSingleTextObject.Id;
            SqlItem.SqlIconable = SqlIconableObject.Id;
            SqlItem.ListType = ListType;
            Procedures.Insert(SqlItem);
        }
        public ListBasic(SqlList list)
        {
            SqlItem = list;
            SqlSingleText st = Procedures.SingleTexts[list.SqlSingleText];
            SqlIconable i = Procedures.Iconables[list.SqlIconable];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

            //IIconable
            SqlIconableObject = i;
            ImageSource = i.ImageSource;

            //ICategryStorage
            Categories = new List<CategoryBase>();
            foreach (SqlCategoryStorage s in Procedures.CategoryStorages.Values)
            {
                if (s.ListId != SqlItem.Id) continue;
                SqlCategory sqlc = Procedures.Categories[s.CategoryId];
                CategoryBase cat = GetCategory(sqlc);
                Categories.Add(cat);
            }
        }
    }
}

using ATLists.Interfaces;
using ATLists.SQL;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace ATLists
{
    public class CategoryBasic : CategoryBase, ISingleTextStorage, IIconable, IEntryStorage //IColorable
    {
        public override string CategoryType
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



        //IEntryStorage
        public List<EntryBase> Entries
        {
            get;
            private set;
        }
        public void AddEntry(EntryBase entry)
        {
            Entries.Add(entry);

            //save to DataBase
            SqlEntryStorage ses = new SqlEntryStorage()
            {
                CategoryId = SqlItem.Id,
                EntryId = entry.SqlItem.Id
            };
            Procedures.Insert(ses);
        }
        public void RemoveEntry(EntryBase entry)
        {
            Entries.Remove(entry);

            //remove from DataBase
            //Procedures.RemoveEntry(entry.SqlItem.Id);
        }
        public EntryBase GetEntry(SqlEntry sqle)
        {
            EntryBase entry = null;
            entry = EntryFactory.GetEntry(sqle);
            return entry;
        }


        //Ctor
        public CategoryBasic(string text, string iconName = null)
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

            //IEntryStorage
            Entries = new List<EntryBase>();

            //Set SQLCategory
            SqlItem = new SqlCategory();
            //SqlItem.SqlColorable = SqlColorableObject.Id;
            SqlItem.SqlSingleText = SqlSingleTextObject.Id;
            SqlItem.SqlIconable = SqlIconableObject.Id;
            SqlItem.CategoryType = CategoryType;
            Procedures.Insert(SqlItem);
        }
        public CategoryBasic(SqlCategory cat)
        {
            SqlItem = cat;
            SqlSingleText st = Procedures.SingleTexts[cat.SqlSingleText];
            //SqlColorable c = Procedures.Colorables[cat.SqlColorable];
            SqlIconable i = Procedures.Iconables[cat.SqlIconable];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

            //IIconable
            SqlIconableObject = i;
            ImageSource = i.ImageSource;

            Entries = new List<EntryBase>();
            foreach (SqlEntryStorage s in Procedures.EntryStorages.Values)
            {
                if (s.CategoryId != SqlItem.Id) continue;
                SqlEntry sqle = Procedures.Entries[s.EntryId];
                EntryBase entry = GetEntry(sqle);
                Entries.Add(entry);
            }
        }
    }
}

using ATLists.Interfaces;
using ATLists.SQL;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace ATLists
{
    public class CategoryBasic : CategoryBase, ISingleTextStorage, IIconable, IEntryStorage //IColorable
    {
        public override CategoryType CategoryType
        {
            get
            {
                return CategoryType.Basic;
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



        //IEntryStorage
        public SqlEntryStorage SqlEntryStorageObject
        {
            get;
            private set;
        }
        public List<EntryBase> Entries
        {
            get;
            private set;
        }
        public void AddEntry(EntryBase entry)
        {
            Entries.Add(entry);

            //save to DataBase
            List<byte> ids = new List<byte>();
            foreach (EntryBase e in Entries) ids.Add((byte)e.SqlItem.Id);
            SqlEntryStorageObject.Entries = ids.ToArray();
            Procedures.Update(SqlEntryStorageObject);

            //update View
        }
        public void RemoveEntry(EntryBase entry)
        {
            Entries.Remove(entry);

            //save to DataBase
            List<byte> ids = new List<byte>();
            foreach (EntryBase e in Entries) ids.Add((byte)e.SqlItem.Id);
            SqlEntryStorageObject.Entries = ids.ToArray();
            Procedures.Update(SqlEntryStorageObject);

            //update View
        }
        public virtual EntryBase GetEntry(SqlEntry sqle)
        {
            EntryBase entry = null;
            entry = new EntryBasic(sqle);
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

            //IEntryStorage
            Entries = new List<EntryBase>();
            SqlEntryStorageObject = new SqlEntryStorage();
            Procedures.Insert(SqlEntryStorageObject);

            //Set SQLCategory
            SqlItem = new SqlCategory();
            //SqlItem.SqlColorable = (byte)SqlColorableObject.Id;
            SqlItem.SqlSingleText = (byte)SqlSingleTextObject.Id;
            SqlItem.SqlIconable = (byte)SqlIconableObject.Id;
            SqlItem.SqlEntryStorage = (byte)SqlEntryStorageObject.Id;
            SqlItem.CategoryType = (int)CategoryType;
            Procedures.Insert(SqlItem);
        }
        public CategoryBasic(SqlCategory cat)
        {
            SqlSingleText st = Procedures.SingleTexts[cat.SqlSingleText];
            //SqlColorable c = Procedures.Colorables[cat.SqlColorable];
            SqlIconable i = Procedures.Iconables[cat.SqlIconable];
            SqlEntryStorage es = Procedures.EntryStorages[cat.SqlEntryStorage];

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

            //IEntryStorage
            SqlEntryStorageObject = es;
            Entries = new List<EntryBase>();
            foreach (byte b in es.Entries)
            {
                SqlEntry sqle = Procedures.Entries[b];
                EntryBase entry = GetEntry(sqle);
                Entries.Add(entry);
            }
        }
    }
}

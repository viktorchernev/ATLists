using ATLists.Interfaces;
using ATLists.SQL;
using Newtonsoft.Json;
using System.Collections.Generic;
//using System.Drawing;

namespace ATLists
{
    public class EntryBasic : EntryBase, ISingleTextStorage //IColorable
    {
        public override string EntryType
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



        //Ctor
        public EntryBasic(string text)
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

            //Set SQLEntry
            SqlItem = new SqlEntry();
            //SqlItem.SqlColorable = (byte)SqlColorableObject.Id;
            SqlItem.SqlSingleText = (byte)SqlSingleTextObject.Id;
            SqlItem.EntryType = EntryType;
            Procedures.Insert(SqlItem);
        }
        public EntryBasic(SqlEntry e)
        {
            SqlSingleText st = Procedures.SingleTexts[e.SqlSingleText + 1];
            //SqlColorable c = Procedures.Colorables[e.SqlColorable];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

            //IColorable
            //SqlColorableObject = c;
            //ForeColor = Color.FromArgb(c.ForeColor);
            //BackColor = Color.FromArgb(c.BackColor);
            //ForeColors = JsonConvert.DeserializeObject<Dictionary<string, Color>>(c.ForeColorsJson);
            //BackColors = JsonConvert.DeserializeObject<Dictionary<string, Color>>(c.BackColorsJson);
        }
    }
}
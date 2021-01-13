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
        }



        //Ctor
        public EntryBasic(string text)
        {
            //ISingleTextStorage - Data
            Text = text;
            //ISingleTextStorage - SQL
            SqlSingleTextObject = new SqlSingleText() { Text = text };
            Procedures.Insert(SqlSingleTextObject);

            //Set SQLEntry
            SqlItem = new SqlEntry();
            //SqlItem.SqlColorable = SqlColorableObject.Id;
            SqlItem.SqlSingleText = SqlSingleTextObject.Id;
            SqlItem.EntryType = EntryType;
            Procedures.Insert(SqlItem);
        }
        public EntryBasic(SqlEntry e)
        {
            SqlItem = e;
            SqlSingleText st = Procedures.SingleTexts[e.SqlSingleText];
            //SqlColorable c = Procedures.Colorables[e.SqlColorable];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;
        }
    }
}
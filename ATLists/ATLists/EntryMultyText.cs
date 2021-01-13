using ATLists.Interfaces;
using ATLists.SQL;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ATLists
{
    public class EntryMultyText : EntryBase, ISingleTextStorage, IMultiTextStorage
    {
        public override string EntryType
        {
            get
            {
                return "MultyText";
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



        //IMultyTextStorage
        public SqlMultyText SqlMultyTextObject
        {
            get;
            private set;
        }
        public Dictionary<string, string> Texts
        {
            get;
            private set;
        }
        public void AddText(string key, string text)
        {
            if (Texts.ContainsKey(key))
            {
                Texts[key] = text;
            }
            else
            {
                Texts.Add(key, text);
            }

            //Save to DB
            SqlMultyTextObject.TextsJson = JsonConvert.SerializeObject(Texts);
            Procedures.Update(SqlMultyTextObject);
        }
        public void RemoveText(string key)
        {
            if (Texts.ContainsKey(key))
            {
                Texts.Remove(key);

                //Save to DB
                SqlMultyTextObject.TextsJson = JsonConvert.SerializeObject(Texts);
                Procedures.Update(SqlMultyTextObject);
            }
        }



        public EntryMultyText(params string[] texts)
        {
            //Input check
            //We expect input like "key1", "value1", "key2", "value2", ...
            //So, even number of strings must be provided as params
            if (texts.Length % 2 > 0)
            {
                throw new System.Exception("Input an even number of strings in key-value fashion");
            }

            //IMultyTextStorage - Data
            Texts = new Dictionary<string, string>();
            for (int i = 0; i < texts.Length; i += 2)
            {
                Texts.Add(texts[i], texts[i + 1]);
            }
            //IMultyTextStorage - SQL
            SqlMultyTextObject = new SqlMultyText();
            SqlMultyTextObject.TextsJson = JsonConvert.SerializeObject(Texts);
            Procedures.Insert(SqlMultyTextObject);


            string txt = (texts.Length > 0) ? texts[1] : "";
            //ISingleTextStorage - Data
            Text = txt;
            //ISingleTextStorage - SQL
            SqlSingleTextObject = new SqlSingleText() { Text = txt };
            Procedures.Insert(SqlSingleTextObject);

            //Set SQLEntry
            SqlItem = new SqlEntry();
            SqlItem.SqlMultyText = SqlMultyTextObject.Id;
            SqlItem.SqlSingleText = SqlSingleTextObject.Id;
            SqlItem.EntryType = EntryType;
            Procedures.Insert(SqlItem);
        }
        public EntryMultyText(SqlEntry e)
        {
            SqlItem = e;
            SqlSingleText st = Procedures.SingleTexts[e.SqlSingleText];
            SqlMultyText mt = Procedures.MultyTexts[e.SqlMultyText];

            //SqlSingleText
            SqlSingleTextObject = st;
            Text = st.Text;

            //IMultiTextStorage
            SqlMultyTextObject = mt;
            Texts = new Dictionary<string, string>();
            Texts = JsonConvert.DeserializeObject<Dictionary<string, string>>(mt.TextsJson);
        }
    }
}
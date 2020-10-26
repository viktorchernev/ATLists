using System.Collections.Generic;
//using System.Drawing;
using ATLists;
using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface IColorable
    {
        //SQLObject
        SqlColorable SqlColorableObject { get; }


        //Data Storage
        //Color ForeColor { get; }
        //Color BackColor { get; }
        //Dictionary<string, Color> ForeColors { get; }
        //Dictionary<string, Color> BackColors { get; }


        ////Data Setters
        //void SetForeColor(Color color);
        //void SetBackColor(Color color);
        //void SetColorTheme(string key);


        //void AddForeColor(string key, Color color);
        //void AddBackColor(string key, Color color);

        //void RemoveForeColor(string key);
        //void RemoveBackColor(string key);


        //Compound Getters
    }
}
//public interface IColorable
//{
//    ItemColorTheme ColorTheme { get; }
//    Dictionary<Type, ItemColorTheme> Themes { get; }


//    void SetColorTheme(ItemColorTheme theme);
//    void SetColorTheme(Type type);


//    void AddColorTheme(Type type, ItemColorTheme theme);
//    void RemoveColorTheme(Type type);
//}
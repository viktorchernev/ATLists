using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface ISingleTextStorage
    {
        //SQLObject
        SqlSingleText SqlSingleTextObject { get; }


        //Data Storage
        string Text { get; }


        //Data Setters
        void SetText(string text);


        //Compound Getters
    }
}

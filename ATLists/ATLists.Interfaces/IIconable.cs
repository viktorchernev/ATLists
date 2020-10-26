using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface IIconable
    {
        //SQLObject
        SqlIconable SqlIconableObject { get; }


        //Data Storage
        string ImageSource { get; }


        //Data Setters
        void SetImage(string source);


        //Compound Getters
    }
}

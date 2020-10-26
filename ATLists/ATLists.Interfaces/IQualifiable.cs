using ATLists.Basics;
using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface IQualifiable
    {
        //SQLObject
        SqlQualifiable SqlQualifiableObject { get; }


        //Data Storage
        ItemQuality Quality { get; }


        //Data Setters
        void SetPercentage(double percentage);
        void SetNumberOfStars(int numOfStars);
        void SetStarts(double stars);


        //Compound Getters
    }
}

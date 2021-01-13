using ATLists.SQL;
using System.Collections.Generic;

namespace ATLists.Interfaces
{
    public interface ICategoryStorage
    {
        //Data Storage
        List<CategoryBase> Categories { get; }


        //Data Setters
        void AddCategory(CategoryBase category);
        void RemoveCategory(CategoryBase category);


        //Compound Getters
        CategoryBase GetCategory(SqlCategory sqlc);
    }
}
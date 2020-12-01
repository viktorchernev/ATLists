using ATLists.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATLists
{
    public static class CategoryFactory
    {
        static Dictionary<string, Func<SqlCategory, CategoryBase>> REGISTER;


        static CategoryFactory()
        {
            REGISTER = new Dictionary<string, Func<SqlCategory, CategoryBase>>();
            REGISTER.Add("Basic", GetCategoryBasic);
        }


        public static CategoryBase GetCategory(SqlCategory sqlc)
        {
            foreach (KeyValuePair<string, Func<SqlCategory, CategoryBase>> kvp in REGISTER)
            {
                if (kvp.Key == sqlc.CategoryType)
                {
                    return kvp.Value(sqlc);
                }
            }

            return null;
        }


        public static CategoryBasic GetCategoryBasic(SqlCategory sqlc)
        {
            return new CategoryBasic(sqlc);
        }
    }
}
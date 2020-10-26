using ATLists.Basics;
using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface IQuantifiable
    {
        //SQLObject
        SqlQuantifiable SqlQuantifiableObject { get; }


        //Data Storage
        /// <summary>
        /// The Quantity struct.
        /// </summary>
        ItemQuantity Quantity { get; set; }


        //Data Setters
        /// <summary>
        /// Update the ammount of this item and update the database.
        /// </summary>
        /// <param name="ammount">The new ammount</param>
        void SetAmmount(double ammount);
        void SetAmmountSuffix(string suffix);
        void SetAmmountShortSuffix(string suffix);
        void SetABTreshold(int treshold);
        void SetSeparator(string separator);
        void SetShortSeparator(string separator);
        void SetAmmountSuffix2(string suffix);
        void SetAmmountShortSuffix2(string suffix);


        /// <summary>
        /// Update the ShowOne value, saving the new state to the DB.
        /// </summary>
        /// <param name="showone">The desired value</param>
        void SetShowOne(bool showone);
        /// <summary>
        /// Update the ShowZero value, saving the new state to the DB.
        /// </summary>
        /// <param name="showzero">The desired value</param>
        void SetShowZero(bool showzero);
        /// <summary>
        /// Update the WarningAmmount value, saving the new state to the DB.
        /// </summary>
        /// <param name="warningAmmount">The desired value</param>
        void SetWarningAmmount(double warningAmmount);
        /// <summary>
        /// Update the CriticalAmmount value, saving the new state to the DB.
        /// </summary>
        /// <param name="criticalAmmount">The desired value</param>
        void SetCriticalAmmount(double criticalAmmount);



        //Compound Getters
        string AmmountText { get; }
        string AmmountShortText { get; }
    }
}

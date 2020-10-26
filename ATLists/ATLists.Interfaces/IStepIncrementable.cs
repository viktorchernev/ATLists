using ATLists.Basics;
using ATLists.SQL;

namespace ATLists.Interfaces
{
    public interface IStepIncrementable : IQuantifiable
    {
        //SQLObject
        //SqlStepIncrementable SqlObject { get; }


        //Data Storage
        ItemStepIncrement _increment { get; set; }
        ItemStepIncrement _decrement { get; set; }


        //Data Setters
        void SetDecrementAmmount(double ammount);
        void SetDecrementText(string text);
        void SetIncrementAmmount(double ammount);
        void SetIncrementText(string text);

        void StepIncrement(int multiplier);
        void StepIncrement();
        void StepDecrement(int multiplier);
        void StepDecrement();


        //Compound Getters
    }
}
//DecrementFirstDecrement()
//Decrement(decrementkey)

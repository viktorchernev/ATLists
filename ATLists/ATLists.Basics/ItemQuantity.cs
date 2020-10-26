namespace ATLists.Basics
{
    public class ItemQuantity
    {
        /// <summary>
        /// The Ammount of this item, or how many is there of the item
        /// </summary>
        public double Ammount { get; set; }
        public string AmmountSuffix { get; set; }
        public string AmmountShortSuffix { get; set; }
        public int ABTreshold { get; set; }
        public string Separator { get; set; }
        public string ShortSeparator { get; set; }
        public string AmmountSuffix2 { get; set; }
        public string AmmountShortSuffix2 { get; set; }



        /// <summary>
        /// Wether to show a number if there is 1 of the item
        /// </summary>
        public bool ShowOne { get; set; }
        /// <summary>
        /// Wether to show a number if there is 0 of the item
        /// </summary>
        public bool ShowZero { get; set; }


        public double WarningAmmount { get; set; }
        public double CriticalAmmount { get; set; }
    }
}

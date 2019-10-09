using System;
using System.Windows.Media.Imaging;

namespace CardCreator.Model
{
    class CardData
    {

        internal enum Type
        {
            Dragon,
            Orc,
            Snail,
        }

        public CardData()
        {
            Attack = 5;
            Defence = 4;
            Cost = 3;
            Name = "";
            AllTypes = Enum.GetNames(typeof(Type));
            
        }

        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        public string[] AllTypes { get; set; }
        public BitmapImage Image { get; set; }
    }
}

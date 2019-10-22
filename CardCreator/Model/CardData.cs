using System;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;


namespace CardCreator.Model
{
    class CardData
    {
        public CardData()
        {
            Attack = 0;
            Defence = 0;
            Cost = 0;
            Name = "";
            AllTypes = LoadTypesToCombobox();

        }

        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        public string[] AllTypes { get; set; }
        public BitmapImage Image { get; set; }
        public string ImageSource { get; set; }

        public int MinAtk { get; set; }
        public int MaxAtk { get; set; }
        public int MaxDef { get; set; }
        public int MinDef { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }
        public string TypeName { get; set; }


        public string[] LoadTypesToCombobox()
        {
            using (var context = new CCContext())
            {
                var types = context.Types.GroupBy(t => t.Id);
                string[] typeArray = new string[types.Count()];
                int i = 0;

                foreach (var groupItem in types)
                {
                    foreach (var type in groupItem)
                    {
                        typeArray[i] = type.Name;
                        i++;
                    }
                }
                return typeArray;
            }
        }

        public void updateCombobox()
        {
            AllTypes = LoadTypesToCombobox();
        }

        public void createCard(string name, int attack, int defence, int cost, Type type, string imgSource)
        {
            using (var context = new CCContext())
            {
                var cards = new Card()
                {
                    Name = name,
                    Attack = attack,
                    Defence = defence,
                    Cost = cost,
                    Type = type,
                    Image = imgSource
                };
                context.Cards.Add(cards);

                context.SaveChanges();
                Console.WriteLine("Added to database");

            }
        }
    }

}

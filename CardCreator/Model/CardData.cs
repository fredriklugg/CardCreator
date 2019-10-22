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
            AllTypes = GetTypesToCombobox();

        }

        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        public string[] AllTypes { get; set; }
        public BitmapImage Image { get; set; }
        public string ImageSource { get; set; }



        public string[] GetTypesToCombobox()
        {
            using (var context = new CCContext())
            {
                var types = context.Types.GroupBy(s => s.Id);
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

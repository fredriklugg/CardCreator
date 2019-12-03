using System;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;


namespace CardCreator.Model
{
    public class CardData
    {
        public CardData()
        {
            Attack = 0;
            Defence = 0;
            Cost = 0;
            Name = "";
            AllTypes = LoadTypesToCombobox();

        }

        public CardData(int atk, int def, int cost, string name, string type)
        {
            Attack = atk;
            Defence = def;
            Cost = cost;
            Name = name;
            TypeName = type;
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
                var types = context.Types.GroupBy(t => t.TypeId);
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

        public void createNewCard(string name, int atk, int def, int cost, string imgsource, string SelectedType)
        {
            using (var context = new CCContext())
            {
                var type = context.Types.First(t => t.Name == SelectedType);

                var cards = new Card
                {
                    Name = Name,
                    Attack = Attack,
                    Defence = Defence,
                    Cost = Cost,
                    TypeId = type.TypeId,
                    Image = ImageSource
                };
                context.Cards.Add(cards);
                context.SaveChanges();
                Console.WriteLine("Added to database");
            }
        }
    }

}

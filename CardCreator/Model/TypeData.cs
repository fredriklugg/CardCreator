using System;
using System.Windows.Media.Imaging;
using Microsoft.EntityFrameworkCore.Design;
using System.Linq;


namespace CardCreator.Model
{
    class TypeData
    {
        public TypeData()
        {
            Name = "";
            MinAttack = 0;
            MaxAttack = 0;
            MinDefence = 0;
            MaxDefence = 0;
            MinCost = 0;
            MaxCost = 0;
        }

        public string Name { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int MinDefence { get; set; }
        public int MaxDefence { get; set; }
        public int MinCost { get; set; }
        public int MaxCost { get; set; }

        public void createType(string name, int minAtk, int maxAtk, int minDef, int maxDef, int minCost, int maxCost)
        {
            using (var context = new CCContext())
            {
                var type = new Type()
                {
                    Name = name,
                    Min_Attack = minAtk,
                    Max_Attack = maxAtk,
                    Min_Defence = minDef,
                    Max_Defence = maxDef,
                    Min_Cost = minCost,
                    Max_Cost = maxCost,
                };
                context.Types.Add(type);

                context.SaveChanges();
                Console.WriteLine("Added type to database");

            }
        }
    }

}

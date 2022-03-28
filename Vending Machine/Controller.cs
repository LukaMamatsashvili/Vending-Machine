using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vending_Machine.Strategy;

namespace Vending_Machine
{
    public enum ItemType
    {
        Chips,
        Chocolate,
        Drink,
        Sandwich
    }
    public enum ItemName
    {
        Doritos,
        Pringles,
        Lays,
        Snickers,
        Twix,
        KitKat,
        Monster,
        Water,
        Sprite,
        Egg,
        Chicken,
        Ham
    }
    public class ItemInfo
    { 
        public string Code { get; set; }
        public ItemType Type { get; set; }
        public ItemName Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity = new Random().Next(0, 10);
    }

    public class Controller
    {
        public IVM ivm;
        public ItemInfo Item { get; set; }
        public List<ItemInfo> Items { get; set; } = new List<ItemInfo>();
        public string Code { get; set; }
        public ItemType Type { get; set; }
        public ItemName Name { get; set; }
        public int Quantity { get; set; }
        public void SetStrategy(IVM _ivm)
        {
            ivm = _ivm;
        }
        public void ProductsOnCodes(List<ItemInfo> List)
        {
            List<string> Codes = new List<string>() { "A001", "A002", "A003", "B001", "B002", "B003", "C001", "C002", "C003", "D001", "D002", "D003" };
            var r = new Random();
            var shuffledList = Codes.OrderBy(item => r.Next());
            int index = 0;
            foreach (var item in shuffledList)
            {
                List[index].Code = item;
                index++;
            }
        }
        public void DiscountOnTypes(List<ItemInfo> List)
        {
            int r = new Random().Next(0, 4);
            if (r == 0)
            {
                Console.WriteLine("We have 20% discount on Chips.\n");
                foreach (var i in List)
                    if (i.Type == ItemType.Chips) i.Price -= (i.Price * 0.2m);
            }
            else if (r == 1)
            {
                Console.WriteLine("We have 20% discount on Chocolates.\n");
                foreach (var i in List)
                    if (i.Type == ItemType.Chocolate) i.Price -= (i.Price * 0.2m);
            }
            else if (r == 2)
            {
                Console.WriteLine("We have 20% discount on Drinks.\n");
                foreach (var i in List)
                    if (i.Type == ItemType.Drink) i.Price -= (i.Price * 0.2m);
            }
            else if (r == 3)
            {
                Console.WriteLine("We have 20% discount on Sandwiches.\n");
                foreach (var i in List)
                    if (i.Type == ItemType.Sandwich) i.Price -= (i.Price * 0.2m);
            }
        }

        public void VMController()
        {
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chips,
                Name = ItemName.Doritos,
                Price = 4.2m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chips,
                Name = ItemName.Pringles,
                Price = 6.5m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chips,
                Name = ItemName.Lays,
                Price = 3.5m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chocolate,
                Name = ItemName.Snickers,
                Price = 1.6m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chocolate,
                Name = ItemName.Twix,
                Price = 1.5m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Chocolate,
                Name = ItemName.KitKat,
                Price = 1.3m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Drink,
                Name = ItemName.Monster,
                Price = 7
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Drink,
                Name = ItemName.Water,
                Price = 0.8m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Drink,
                Name = ItemName.Sprite,
                Price = 1.4m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Sandwich,
                Name = ItemName.Egg,
                Price = 3.5m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Sandwich,
                Name = ItemName.Chicken,
                Price = 4m
            });
            Items.Add(new ItemInfo
            {
                Type = ItemType.Sandwich,
                Name = ItemName.Ham,
                Price = 5m
            });


            Console.WriteLine("\t\t\t Vending  Machine\n\n\t\t\t------------------\n\t\t\t|A001  A002  A003|\n\t\t\t" +
                              "|B001  B002  B003|\n\t\t\t|C001  C002  C003|\n\t\t\t|D001  D002  D003|\n\t\t\t------------------" +
                              "\n\nAvailable currencies:\n1. GEL\n2. USD\n3. EUR\n\n");
            ProductsOnCodes(Items);
            DiscountOnTypes(Items);

            bool CONT = true;
            while (CONT)
            {
                Console.WriteLine("Choose the currency to buy the product:");
                string currency = Convert.ToString(Console.ReadLine());

                //gel
                if (currency == "GEL" || currency == "gel")
                {
                    CONT = false;
                    
                    GELoption gel = new GELoption();
                    SetStrategy(gel);
                    gel.CurrencyOption(Items);
                }

                //usd
                else if (currency == "USD" || currency == "usd")
                {
                    CONT = false;

                    USDoption usd = new USDoption();
                    SetStrategy(usd);
                    usd.CurrencyOption(Items);
                }

                //eur
                else if (currency == "EUR" || currency == "eur")
                {
                    CONT = false;

                    EURoption eur = new EURoption();
                    SetStrategy(eur);
                    eur.CurrencyOption(Items);
                }
                else Console.WriteLine("\nERROR: Incorrect answer!\n");
            }
        }
    }
}
